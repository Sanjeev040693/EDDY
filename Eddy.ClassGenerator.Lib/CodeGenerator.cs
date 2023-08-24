﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Eddy.Core.Validation;

namespace Eddy.ClassGenerator.Lib;

public class ParsedSegment
{
    public string SegmentType { get; set; }
    public string ClassName { get; set; }
    public List<Model> Items { get; set; } = new();

    public override bool Equals(object obj)
    {
        var compareTo = obj as ParsedSegment;
        if (compareTo == null)
            return false;

        if (this.Items.Count != compareTo.Items.Count)
            return false;

        for (var index = 0; index < this.Items.Count; index++)
        {
            if (!this.Items[index].DeepEquals(compareTo.Items[index]))
                return false;
        }
        return true;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(SegmentType, ClassName, Items);
    }
}

public class CodeGenerator
{
  
  //  private string StripTypeFromPostion(string input)
   // {
   //     return input.Substring(input.IndexOf("-") + 1).Replace(",", "").Trim();
   // }

    private Model FindFieldByPosition(string position, List<Model> fields)
    {
        foreach (var field in fields)
        {
            if (position == field.Position)
            {
                return field;
            }
        }
        return new Model(position, position, "string", 0, 0);
    }

    private static string RemoveSpecialCharacters(string input)
    {
        return input.Replace("/", "").Replace(" ", "").Replace("-", "").Replace(",", "").Replace("(", "").Replace(")", "").Replace("'", "").Replace(".", "");
    }

    public static string GetCodeClassName(string segmentType, string friendlyName)
    {
        return segmentType + "_" + RemoveSpecialCharacters(friendlyName);
    }

    public string GenerateCode(ParsedSegment parsed, ParseType parseType, string namespaceVersion)
    {
        var sb = new StringBuilder();
        if (parseType == ParseType.x12Segment || parseType == ParseType.x12Element)
        {
            sb.AppendLine("using Eddy.Core.Attributes;");
            sb.AppendLine("using Eddy.Core.Validation;");
            sb.AppendLine("using Eddy.x12.Models.Elements;");
            sb.AppendLine();
            if (parseType == ParseType.x12Element)
                sb.AppendLine("namespace Eddy.x12.Models.Elements;");
            else
                sb.AppendLine("namespace Eddy.x12.Models.v" + namespaceVersion + ";");
            sb.AppendLine();
            sb.AppendLine($"[Segment(\"{parsed.SegmentType}\")]");
            sb.Append($"public class {parsed.ClassName} : ");
            sb.AppendLine(parseType == ParseType.x12Element ? "EdiX12Component" : "EdiX12Segment");
        }
        else if (parseType == ParseType.ediFactElement)
            sb.AppendLine($"public class {parsed.ClassName} : IElement ");
        else if (parseType == ParseType.ediFactSegment)
            sb.AppendLine($"public class {parsed.ClassName} ");
        sb.AppendLine("{");

        foreach (var item in parsed.Items) sb.AppendLine(item.ToString());


        sb.AppendLine("\tpublic override ValidationResult Validate()");
        sb.AppendLine("\t{");
        sb.AppendLine($"\t\tvar validator = new BasicValidator<{parsed.ClassName}>(this);");

        //required validations
        foreach (var model in parsed.Items)
        {
            if (model.IsRequired)
            {
                sb.AppendLine($"\t\tvalidator.Required(x=>x.{model.Name});");
            }

            foreach (var x in model.AtLeastOneValidations)
            {
                sb.AppendLine($"\t\tvalidator.AtLeastOneIsRequired(x=>x.{FindFieldByPosition(x.FirstFieldPosition, parsed.Items).Name}, x=>x.{FindFieldByPosition(x.OtherFields[0], parsed.Items).Name});");
            }

            foreach (var x in model.IfOneIsFilledAllAreRequiredValidations)
            {
               sb.AppendLine($"\t\tvalidator.IfOneIsFilled_AllAreRequired(x=>x.{FindFieldByPosition(x.FirstFieldPosition, parsed.Items).Name}, x=>x.{FindFieldByPosition(x.OtherFields[0], parsed.Items).Name});");
            }

            foreach (var x in model.ARequiresBValidation)
            {
                sb.AppendLine($"\t\tvalidator.ARequiresB(x=>x.{FindFieldByPosition(x.FirstFieldPosition, parsed.Items).Name}, x=>x.{FindFieldByPosition(x.OtherFields[0], parsed.Items).Name});");
            }

            foreach (var x in model.OnlyOneOfValidations)
            {
                sb.AppendLine($"\t\tvalidator.OnlyOneOf(x=>x.{FindFieldByPosition(x.FirstFieldPosition, parsed.Items).Name}, x=>x.{FindFieldByPosition(x.OtherFields[0], parsed.Items).Name});");
            }

            foreach (var x in model.IfOneIsFilledThenAtLeastOne)
            {
                sb.Append($"\t\tvalidator.IfOneIsFilledThenAtLeastOne(x=>x.{FindFieldByPosition(x.FirstFieldPosition, parsed.Items).Name}");
                foreach (var otherField in x.OtherFields)
                {
                    sb.Append($", x=>x.{FindFieldByPosition(otherField, parsed.Items).Name}");
                }
                sb.AppendLine(");");
            }
        }

        //length validations
        foreach (var model in parsed.Items)
        {
            if (model.Min == 0 && model.Max == 0) //it is a complex type and should not be validated
                continue;
            else if (model.Min == model.Max)
                sb.AppendLine($"\t\tvalidator.Length(x => x.{model.Name}, {model.Min});");
            else
                sb.AppendLine($"\t\tvalidator.Length(x => x.{model.Name}, {model.Min}, {model.Max});");
        }

        sb.AppendLine("\t\treturn validator.Results;");
        sb.AppendLine("\t}");

        sb.AppendLine("}");
      

       
        return sb.ToString();
    }

    public string GenerateTests(ParsedSegment parsed, ParseType parseType, string namespaceVersion)
    {
        var sbTest = new StringBuilder();
        sbTest.AppendLine("using Eddy.Core.Validation;");
        sbTest.AppendLine("using Eddy.Tests.x12;");
        sbTest.AppendLine("using Eddy.x12.Mapping;");
        sbTest.AppendLine("using Eddy.x12.Models.v" + namespaceVersion + ";");
        sbTest.AppendLine();
        sbTest.AppendLine("namespace Eddy.x12.Tests.Models.v" + namespaceVersion + ";");
        sbTest.AppendLine();
        sbTest.AppendLine($"public class {parsed.SegmentType}Tests");
        sbTest.AppendLine("{");
        sbTest.AppendLine("\t[Fact]");
        sbTest.AppendLine("\tpublic void Parse_ShouldReturnCorrectObject()");
        sbTest.AppendLine("\t{");
        if (parseType == ParseType.x12Element)
        {
            sbTest.Append($"\t\tvar x12Line = \"");
        }
        else
        {
            sbTest.Append($"\t\tstring x12Line = \"{parsed.SegmentType}");
        }
        foreach (var model in parsed.Items)
        {
            sbTest.Append("*" + model.TestValue);
        }
        sbTest.AppendLine("\";");
        sbTest.AppendLine("");
        sbTest.AppendLine($"\t\tvar expected = new {parsed.ClassName}()");
        sbTest.AppendLine("\t\t{");
        foreach (var model in parsed.Items)
        {
            if (model.IsDataTypeNumeric)
                sbTest.AppendLine($"\t\t\t{model.Name} = {model.TestValue},");
            else
                sbTest.AppendLine($"\t\t\t{model.Name} = \"{model.TestValue}\",");
        }
        sbTest.AppendLine("\t\t};");
        sbTest.AppendLine("");
        sbTest.AppendLine($"\t\tvar actual = Map.MapObject<{parsed.ClassName}>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);");
        sbTest.AppendLine("\t\tAssert.Equivalent(expected, actual);");
        sbTest.AppendLine("\t}");
        sbTest.AppendLine();

        foreach (var model in parsed.Items)
        {
            if (model.IsRequired)
            {
                sbTest.AppendLine("\t[Theory]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(model, true)}, false)]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(model, false)}, true)]");
                sbTest.Append($"\tpublic void Validation_Required{model.Name}(");
                sbTest.Append($"{model.DataType.Replace("?", "")} {FirstCharToLowerCase(model.Name)}, "); //can not pass in a nullable with inline data
                sbTest.AppendLine($"bool isValidExpected)");
                sbTest.AppendLine("\t{");
                sbTest.AppendLine($"\t\tvar subject = new {parsed.ClassName}();");
                foreach (var requiredItem in parsed.Items.Where(x => x.IsRequired && x.Name != model.Name))
                {
                    if (requiredItem.IsDataTypeNumeric)
                        sbTest.AppendLine($"\t\tsubject.{requiredItem.Name} = {requiredItem.TestValue};");
                    else
                        sbTest.AppendLine($"\t\tsubject.{requiredItem.Name} = \"{requiredItem.TestValue}\";");

                }

                if (model.IsDataTypeNumeric)
                {
                    sbTest.AppendLine($"\t\tif ({FirstCharToLowerCase(model.Name)} > 0)");
                }
                sbTest.AppendLine($"\t\tsubject.{model.Name} = {FirstCharToLowerCase(model.Name)};");
                sbTest.AppendLine("\t\tTestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);");
                sbTest.AppendLine("\t}");
                sbTest.AppendLine();
            }



            if (model.IfOneIsFilledAllAreRequiredValidations.Any())
            {
                var orderedFields = OrderFieldsForTestSignature(model.IfOneIsFilledAllAreRequiredValidations, parsed.Items);
                sbTest.AppendLine("\t[Theory]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)},{GenerateInlineDataValue(orderedFields[1], true)}, true)]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], false)}, {GenerateInlineDataValue(orderedFields[1], false)}, true)]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)}, {GenerateInlineDataValue(orderedFields[1], false)}, false)]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], false)}, {GenerateInlineDataValue(orderedFields[1], true)}, false)]");
                sbTest.Append($"\tpublic void Validation_AllAreRequired{model.Name}(");
                sbTest.AppendLine(GenerateTestBody(model.IfOneIsFilledAllAreRequiredValidations, parsed.Items, parsed.ClassName));
                sbTest.AppendLine($"\t\tTestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.{nameof(ErrorCodes.IfOneIsFilledAllAreRequired)});");
                sbTest.AppendLine("\t}");
                sbTest.AppendLine();
            }

            if (model.ARequiresBValidation.Any())
            {
                var orderedFields = OrderFieldsForTestSignature(model.ARequiresBValidation, parsed.Items);
                sbTest.AppendLine("\t[Theory]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)}, {GenerateInlineDataValue(orderedFields[1], true)}, true)]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)}, {GenerateInlineDataValue(orderedFields[1], false)}, true)]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], false)}, {GenerateInlineDataValue(orderedFields[1], true)}, false)]");
                sbTest.Append($"\tpublic void Validation_ARequiresB{model.Name}(");
                sbTest.AppendLine(GenerateTestBody(model.ARequiresBValidation, parsed.Items, parsed.ClassName));
                sbTest.AppendLine($"\t\tTestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.{nameof(ErrorCodes.ARequiresB)});");
                sbTest.AppendLine("\t}");
                sbTest.AppendLine();
            }

            if (model.AtLeastOneValidations.Any())
            {
                var orderedFields = OrderFieldsForTestSignature(model.AtLeastOneValidations, parsed.Items);
                sbTest.AppendLine("\t[Theory]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)},{GenerateInlineDataValue(orderedFields[1], true)}, false)]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], false)},{GenerateInlineDataValue(orderedFields[1], false)}, true)]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)}, {GenerateInlineDataValue(orderedFields[1], false)}, true)]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], false)}, {GenerateInlineDataValue(orderedFields[1], true)}, true)]");
                sbTest.Append($"\tpublic void Validation_AtLeastOne{model.Name}(");
                sbTest.AppendLine(GenerateTestBody(model.AtLeastOneValidations, parsed.Items, parsed.ClassName));
                sbTest.AppendLine($"\t\tTestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.{nameof(ErrorCodes.AtLeastOneIsRequired)});");
                sbTest.AppendLine("\t}");
                sbTest.AppendLine();
            }

            if (model.OnlyOneOfValidations.Any())
            {
                var orderedFields = OrderFieldsForTestSignature(model.OnlyOneOfValidations, parsed.Items);
                sbTest.AppendLine("\t[Theory]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)}, {GenerateInlineDataValue(orderedFields[1], true)}, true)]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], false)}, {GenerateInlineDataValue(orderedFields[1], false)}, false)]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)}, {GenerateInlineDataValue(orderedFields[1], false)}, true)]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], false)}, {GenerateInlineDataValue(orderedFields[1], true)}, true)]");
                sbTest.Append($"\tpublic void Validation_OnlyOneOf{model.Name}(");
                sbTest.AppendLine(GenerateTestBody(model.OnlyOneOfValidations, parsed.Items, parsed.ClassName));
                sbTest.AppendLine($"\t\tTestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.{nameof(ErrorCodes.OnlyOneOf)});");
                sbTest.AppendLine("\t}");
                sbTest.AppendLine();
            }

            if (model.IfOneIsFilledThenAtLeastOne.Any())
            {
                var orderedFields = OrderFieldsForTestSignature(model.IfOneIsFilledThenAtLeastOne, parsed.Items);
                sbTest.AppendLine("\t[Theory]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)},{GenerateInlineDataValue(orderedFields[1], true)}, true)]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], false)}, {GenerateInlineDataValue(orderedFields[1], false)}, true)]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)},{GenerateInlineDataValue(orderedFields[1], false)}, true)]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], false)}, {GenerateInlineDataValue(orderedFields[1], true)}, true)]");
                sbTest.Append($"\tpublic void Validation_IfOneSpecifiedThenOneMoreRequired_{model.Name}(");
                sbTest.AppendLine(GenerateTestBody(model.IfOneIsFilledThenAtLeastOne, parsed.Items, parsed.ClassName));
                sbTest.AppendLine($"\t\tTestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.{nameof(ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired)});");
                sbTest.AppendLine("\t}");
                sbTest.AppendLine();
            }
        }
        sbTest.AppendLine("}");
        return sbTest.ToString();
    }

    private string GenerateInlineDataValue(Model item, bool generateBlankDefault)
    {
        if (generateBlankDefault)
        {
            if (item.IsDataTypeNumeric)
                return "0";
            return "\"\"";
        }

        if (item.IsDataTypeNumeric)
            return item.TestValue.ToString();
        return $"\"{item.TestValue}\"";
    }

    private List<Model> OrderFieldsForTestSignature(List<ValidationData> validations, List<Model> items)
    {
        var result = new List<Model>();
        foreach (var validationData in validations)
        {
            foreach (var field in validationData.GetAllFieldDataOrdered())
            {
                var foundField = FindFieldByPosition(field, items);
                result.Add(foundField);
            }
        }
        return result;
    }

     private string GenerateTestBody(List<ValidationData> validations, List<Model> items, string className)
    {
        var sbTest = new StringBuilder();
        foreach (var validationData in validations )
        {
            foreach (var field in validationData.GetAllFieldDataOrdered())
            {
                var foundField = FindFieldByPosition(field, items);
                sbTest.Append($"{foundField.DataType.Replace("?", "")} {FirstCharToLowerCase(foundField.Name)}, ");
            }
        }
        sbTest.AppendLine($"bool isValidExpected)");
        sbTest.AppendLine("\t{");
        sbTest.AppendLine($"\t\tvar subject = new {className}();");
        
        //may impact the test if the variable is used in a validation
        foreach (var requiredItem in items.Where(x => x.IsRequired))
        {
            if (requiredItem.IsDataTypeNumeric)
                sbTest.AppendLine($"\t\tsubject.{requiredItem.Name} = {requiredItem.TestValue};");
            else
                sbTest.AppendLine($"\t\tsubject.{requiredItem.Name} = \"{requiredItem.TestValue}\";");
        }

        foreach (var validationData in validations)
        {
            foreach (var field in validationData.GetAllFieldDataOrdered())
            {
                var otherField = FindFieldByPosition(field, items);
                
                if (otherField.IsDataTypeNumeric)
                {
                    sbTest.AppendLine($"\t\tif ({FirstCharToLowerCase(otherField.Name)} > 0)");
                }
                sbTest.AppendLine($"\t\tsubject.{otherField.Name} = {FirstCharToLowerCase(otherField.Name)};");
            }
        }

     
        return sbTest.ToString();
    }

    private string FirstCharToLowerCase(string str)
    {
        if (!string.IsNullOrEmpty(str) && char.IsUpper(str[0]))
            return str.Length == 1 ? char.ToLower(str[0]).ToString() : char.ToLower(str[0]) + str.Substring(1);
        return str;
    }

    public string GenerateInheritanceCodeFrom(ParsedSegment lastCode, string currentVersion, string lastVersion)
    {
        var sb = new StringBuilder();
        sb.AppendLine("namespace Eddy.x12.Models.v" + currentVersion + ";");
        sb.AppendLine();
        sb.AppendLine($"public class {lastCode.ClassName} : Eddy.x12.Models.v{lastVersion}.{lastCode.ClassName}");
        sb.AppendLine("{");
        sb.AppendLine("}");
        return sb.ToString();
    }
}

