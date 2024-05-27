using System;
using System.Collections.Generic;

public class MyClass
{
    public string ReverseString(string input)
    {
        if (input == null) throw new ArgumentNullException(nameof(input));
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    public int[] DoubleArray(int[] numbers)
    {
        if (numbers == null) throw new ArgumentNullException(nameof(numbers));
        int[] doubled = new int[numbers.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            doubled[i] = numbers[i] * 2;
        }
        return doubled;
    }

    public void VoidMethod()
    {
        // Tu jakas logika metody void
    }

    public void MethodThatThrows()
    {
        throw new InvalidOperationException("An error occurred");
    }

    public event EventHandler MyEvent;

    protected virtual void OnMyEvent()
    {
        MyEvent?.Invoke(this, EventArgs.Empty);
    }

    public void RaiseEvent()
    {
        OnMyEvent();
    }

    private string PrivateMethod()
    {
        return "Private";
    }
}
