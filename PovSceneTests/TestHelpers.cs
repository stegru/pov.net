namespace PovSceneTests
{
    using System;
    using System.Text.RegularExpressions;
    using PovScene.SceneDescription;
    using PovScene.SceneDescription.Items;
    using PovScene.SceneDescription.Items.ObjectModifiers;
    using PovScene.SceneDescription.Items.Objects;
    using PovScene.SceneDescription.Output;
    using Xunit;

    public class TestHelpers
    {
        public static string RemoveSpace(string str)
        {
            Regex redundantSpace = new Regex(@"(?<=[^a-z0-9]|^)\s+(?=\S)|\s+(?=[^\sa-z0-9]|$)", RegexOptions.Compiled);
            Regex whiteSpace = new Regex(@"\s+", RegexOptions.Compiled);
            return whiteSpace.Replace(redundantSpace.Replace(str, ""), " ");
        }

        public static string RenderElement(SceneElement element)
        {
            SceneWriter output = new SceneWriter();
            OutputAttribute outputAttr = OutputAttribute.Combine(element.GetAllAttributes<OutputAttribute>());
            ElementContext sceneContext =
                new ElementContext(new ElementContext(null, new Scene()), element, outputAttr);
            sceneContext.LoadChildren(true);
            sceneContext.Write(output);
            return output.ToString();
        }

        public static void TestString(string actual, string expect)
        {
            Console.Write((actual + "\n").Replace("\n", "\r\n"));
            Assert.Equal(RemoveSpace(expect), RemoveSpace(actual));

        }
        public static void TestElement(SceneElement element, string expect)
        {
            string output = RenderElement(element);
            TestString(output, expect);
        }

        public static void TestSceneItem(SceneItem item, string expect)
        {
            TestElement(item, expect);
        }

        public static void TestSceneObject(SceneObject obj, string expect)
        {
            Regex re = new Regex(@"\$(texture|pigment)");
            TestElement(obj, re.Replace(expect, ""));

            Match match = re.Match(expect);
            if (match.Success)
            {
                SceneElement newObj = null;
                string id = match.Captures[0].Value;
                if (id == "$texture")
                {
                    newObj = obj.Texture = new Texture
                    {
                        Pigment = (1, 2, 3)
                    };
                }
                else if (id == "$pigment")
                {
                    newObj = obj.Pigment = new Pigment.Solid((1, 2, 3));
                }

                string textureOutput = RenderElement(newObj);
                TestElement(obj, re.Replace(expect, textureOutput));
            }
        }
    }
}