using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace TestProjectAO
{
    public class MyClassTests
    {
        private MyClass _myClass;

        [SetUp]
        public void Setup()
        {
            _myClass = new MyClass();
        }

        [Test]
        public void ReverseString_ValidString_ReturnsReversedString()
        {
            var result = _myClass.ReverseString("abc");
            Assert.That(result, Is.EqualTo("cba"));
        }

        [Test]
        public void ReverseString_NullString_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _myClass.ReverseString(null));
        }

        [Test]
        public void DoubleArray_ValidArray_ReturnsDoubledArray()
        {
            var result = _myClass.DoubleArray(new[] { 1, 2, 3 });
            Assert.That(result, Is.EqualTo(new[] { 2, 4, 6 }));
        }

        [Test]
        public void DoubleArray_NullArray_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _myClass.DoubleArray(null));
        }

        [Test]
        public void VoidMethod_NoExceptions()
        {
            Assert.DoesNotThrow(() => _myClass.VoidMethod());
        }

        [Test]
        public void MethodThatThrows_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => _myClass.MethodThatThrows());
        }

        [Test]
        public void RaiseEvent_InvokesMyEvent()
        {
            var eventRaised = false;
            _myClass.MyEvent += (sender, args) => eventRaised = true;

            _myClass.RaiseEvent();

            Assert.That(eventRaised, Is.True);
        }

        [Test]
        public void PrivateMethod_CalledUsingReflection_ReturnsPrivate()
        {
            MethodInfo methodInfo = typeof(MyClass).GetMethod("PrivateMethod", BindingFlags.NonPublic | BindingFlags.Instance);
            var result = (string)methodInfo.Invoke(_myClass, null);

            Assert.That(result, Is.EqualTo("Private"));
        }
    }
}
