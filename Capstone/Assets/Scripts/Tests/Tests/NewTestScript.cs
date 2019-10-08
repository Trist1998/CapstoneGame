using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class NewTestScript
    {

        

        // A Test behaves as an ordinary method
        [Test]
        public void NewTestScriptSimplePasses()
        {

            GameObject gameObject = new GameObject("test");

    Assert.Throws<MissingComponentException>(
        () => gameObject.GetComponent<Rigidbody>().velocity = Vector3.one
    );

            // Use the Assert class to test conditions
        }



        [Test]
        public void NewTestScriptSimplePasses1()
        {
            bool isActive = false;

            Assert.AreEqual(false, isActive);


            // Use the Assert class to test conditions
        }



        public void NewTestScriptSimplePasses2()
        {
          //  User u1;
          



            // Use the Assert class to test conditions
        }


        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator NewTestScriptWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
