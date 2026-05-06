using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;

[CompilerGenerated]
public readonly struct NumericValue : IComparable<NumericValue>, IEquatable<NumericValue>, IFormattable
{
	[CompilerGenerated]
	private static readonly NumericValue _003CZero_003Ek__BackingField = new NumericValue(0);

	[CompilerGenerated]
	private static readonly NumericValue _003CEpsilon_003Ek__BackingField = new NumericValue(1);

	[CompilerGenerated]
	private static readonly NumericValue _003CMaxValue_003Ek__BackingField = new NumericValue(int.MaxValue);

	private bool bool_0;

	private bool bool_1;

	public int RawValue { get; }

	private bool Boolean_0
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	private bool Boolean_1
	{
		get
		{
			return bool_1;
		}
		set
		{
			bool_1 = value;
		}
	}

	private NumericValue(int rawValue)
	{
		RawValue = rawValue;
	}

	public static NumericValue FromObject(object fixedPointObject)
	{
		if (fixedPointObject != null)
		{
			if (!(fixedPointObject is int rawValue))
			{
				if (fixedPointObject is NumericValue)
				{
					return (NumericValue)fixedPointObject;
				}
				try
				{
					Type type = fixedPointObject.GetType();
					PropertyInfo property = type.GetProperty("Value", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					if (!(property != null) || !(property.GetValue(fixedPointObject) is int rawValue2))
					{
						FieldInfo field = type.GetField("Value", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
						if (field != null && field.GetValue(fixedPointObject) is int rawValue3)
						{
							return new NumericValue(rawValue3);
						}
						PropertyInfo property2 = type.GetProperty("RawValue", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
						if (property2 != null && property2.GetValue(fixedPointObject) is int rawValue4)
						{
							return new NumericValue(rawValue4);
						}
						throw new ArgumentException("Объект типа '" + type.FullName + "' не имеет доступного свойства/поля 'Value' или 'RawValue' типа int.");
					}
					return new NumericValue(rawValue2);
				}
				catch (Exception innerException)
				{
					throw new ArgumentException("Неожиданная ошибка при попытке получить значение из объекта типа '" + fixedPointObject.GetType().FullName + "'.", innerException);
				}
			}
			return new NumericValue(rawValue);
		}
		throw new ArgumentNullException("fixedPointObject", "Исходный объект FixedPoint2 не может быть null.");
	}

	public static NumericValue FromInt(int value)
	{
		try
		{
			return new NumericValue(checked(value * 100));
		}
		catch (OverflowException ex)
		{
			throw new ArgumentOutOfRangeException("value", $"Значение {value} слишком велико для преобразования в UniversalFixedPoint2.", ex.ToString());
		}
	}

	public static NumericValue FromFloat(float value)
	{
		return new NumericValue((int)(value * 100f + 1E-05f * (float)Math.Sign(value)));
	}

	public static NumericValue FromDouble(double value)
	{
		return new NumericValue((int)(value * 100.0 + 9.999999747378752E-06 * (double)Math.Sign(value)));
	}

	public float ToFloat()
	{
		return (float)RawValue / 100f;
	}

	public double ToDouble()
	{
		return (double)RawValue / 100.0;
	}

	public int ToInt()
	{
		return RawValue / 100;
	}

	public static NumericValue operator +(NumericValue a, NumericValue b)
	{
		return new NumericValue(a.RawValue + b.RawValue);
	}

	public static NumericValue operator -(NumericValue a, NumericValue b)
	{
		return new NumericValue(a.RawValue - b.RawValue);
	}

	public static NumericValue operator -(NumericValue a)
	{
		return new NumericValue(-a.RawValue);
	}

	public static NumericValue operator *(NumericValue a, int scalar)
	{
		return new NumericValue(a.RawValue * scalar);
	}

	public static NumericValue operator /(NumericValue a, int scalar)
	{
		return new NumericValue(a.RawValue / scalar);
	}

	public static NumericValue operator *(NumericValue a, float b)
	{
		return FromFloat(a.ToFloat() * b);
	}

	public static NumericValue operator *(NumericValue a, double b)
	{
		return FromDouble(a.ToDouble() * b);
	}

	public static NumericValue operator /(NumericValue a, float b)
	{
		return FromFloat(a.ToFloat() / b);
	}

	public static NumericValue operator /(NumericValue a, double b)
	{
		return FromDouble(a.ToDouble() / b);
	}

	public static bool operator ==(NumericValue a, NumericValue b)
	{
		return a.RawValue == b.RawValue;
	}

	public static bool operator !=(NumericValue a, NumericValue b)
	{
		return !(a == b);
	}

	public static bool operator <(NumericValue a, NumericValue b)
	{
		return a.RawValue < b.RawValue;
	}

	public static bool operator >(NumericValue a, NumericValue b)
	{
		return a.RawValue > b.RawValue;
	}

	public static bool operator <=(NumericValue a, NumericValue b)
	{
		return a.RawValue <= b.RawValue;
	}

	public static bool operator >=(NumericValue a, NumericValue b)
	{
		return a.RawValue >= b.RawValue;
	}

	public override bool Equals(object obj)
	{
		if (obj is NumericValue other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(NumericValue other)
	{
		return RawValue == other.RawValue;
	}

	public int CompareTo(NumericValue other)
	{
		return RawValue.CompareTo(other.RawValue);
	}

	public override int GetHashCode()
	{
		return RawValue.GetHashCode();
	}

	public override string ToString()
	{
		return ToDouble().ToString("0.##", CultureInfo.InvariantCulture);
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		return ToDouble().ToString(format ?? "0.##", formatProvider ?? CultureInfo.InvariantCulture);
	}

	public static NumericValue Abs(NumericValue a)
	{
		return new NumericValue(Math.Abs(a.RawValue));
	}

	public static NumericValue Min(NumericValue a, NumericValue b)
	{
		if (!(a < b))
		{
			return b;
		}
		return a;
	}

	public static NumericValue Max(NumericValue a, NumericValue b)
	{
		if (!(a > b))
		{
			return b;
		}
		return a;
	}

	public static NumericValue Clamp(NumericValue number, NumericValue min, NumericValue max)
	{
		if (min > max)
		{
			throw new ArgumentException($"{"min"} {min} не может быть больше {"max"} {max}");
		}
		if (!(number < min))
		{
			if (number > max)
			{
				return max;
			}
			return number;
		}
		return min;
	}
}
