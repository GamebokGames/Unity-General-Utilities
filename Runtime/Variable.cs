using System;

namespace Gamebok.GeneralUtilities
{
    /// <summary>
    /// Represents a generic variable with change notification.
    /// </summary>
    /// <typeparam name="T">Type of the variable.</typeparam>
    public class Variable<T>
    {
        /// <summary>
        /// Event raised when the value of the variable changes.
        /// </summary>
        public event Action<T> Changed;

        /// <summary>
        /// Gets the current value of the variable.
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Variable{T}"/> class.
        /// </summary>
        public Variable()
        {
            // Default constructor, initializes with default value.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Variable{T}"/> class with a specified initial value.
        /// </summary>
        /// <param name="value">Initial value of the variable.</param>
        public Variable(T value)
        {
            Value = value;
        }

        /// <summary>
        /// Forces the variable to a new value and triggers the <see cref="Changed"/>. See <see cref="IEquatable{T}"/>
        /// </summary>
        /// <param name="value">New value to set.</param>
        public void ForceSetValue(T value)
        {
            Value = value;
            Changed?.Invoke(Value);
        }

        /// <summary>
        /// Sets the variable to a new value and triggers the <see cref="Changed"/> event if the new value is different from the current value.
        /// </summary>
        /// <param name="newValue">New value to set.</param>
        public void SetValue(T newValue)
        {
            if (newValue.Equals(Value))
            {
                return;
            }

            Value = newValue;
            Changed?.Invoke(Value);
        }

        /// <summary>
        /// Sets the variable to a new value without triggering the <see cref="Changed"/> event.
        /// </summary>
        /// <param name="newValue">New value to set.</param>
        public void SetSilent(T newValue)
        {
            Value = newValue;
        }
    }
}
