using System;

namespace Synergy.VirusPrototype.Core.Controls
{
	public struct GridLength : IEquatable<GridLength>
	{
		public GridLength(double value, GridUnitType type)
		{
			Value = value;
			UnitType = type;
		}

		public GridUnitType UnitType { get; set; }

		public double Value { get; set; }

		public bool Equals(GridLength other)
		{
			return UnitType == other.UnitType && Value.CompareTo(other.Value) == 0;
		}
	}
}
