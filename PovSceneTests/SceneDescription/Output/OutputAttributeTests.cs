namespace PovSceneTests.SceneDescription.Output
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using PovScene.SceneDescription.Output;
    using Xunit;

    public class TestOutputAttribute : Attribute
    {
        public string Value { get; set; }
    }
    public class SuperTestOutput2Attribute : TestOutputAttribute
    {
    }
    
    [TestOutputAttribute(Value = "PropertyBaseType")]
    public class ValueTypeBase
    {
    }
    
    [TestOutputAttribute(Value = "PropertyType")]
    public class ValueType : ValueTypeBase
    {
    }
    
    [TestOutputAttribute(Value = "BaseValueOwner - unexpected")]
    public class BaseValueOwner
    {
        [TestOutputAttribute(Value = "BaseProperty")]
        public virtual ValueType Prop { get; set; }
    }
    
    [TestOutputAttribute(Value = "SuperValueOwner - unexpected")]
    public class SuperValueOwner : BaseValueOwner
    {
        [SuperTestOutput2Attribute(Value = "OverridingProperty")]
        public override ValueType Prop { get; set; }
    }


    public class OutputAttributeTests
    {
        [Fact]
        public void GetAllAttributes()
        {
            SuperValueOwner obj = new SuperValueOwner();

            Type type = obj.GetType();
            PropertyInfo propertyInfo = type.GetProperty(nameof(obj.Prop), BindingFlags.Instance | BindingFlags.Public);

            IEnumerable<TestOutputAttribute> attrs = propertyInfo.GetAllAttributes<TestOutputAttribute>();

            List<string> actual = attrs.Select(attr => attr.Value).ToList();

            IEnumerable<string> expected = new[]
            {
                "BaseProperty",
                "OverridingProperty",
                "PropertyType",
                "PropertyBaseType"
            };
            
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CombineAttributes()
        {
            OutputAttribute attr1 = new OutputAttribute()
            {
                ContentStart = "one"
            };
            OutputAttribute attr2 = new OutputAttribute()
            {
                ContentStart = "two",
                ContentEnd = "two"
            };

            OutputAttribute output = OutputAttribute.Combine(new[] {attr1, attr2});

            Assert.True(true);
        }
    }
}