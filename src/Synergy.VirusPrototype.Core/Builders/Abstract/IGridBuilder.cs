using Synergy.VirusPrototype.Core.Controls;

namespace Synergy.VirusPrototype.Core.Builders.Abstract
{
	public interface IGridBuilder : IBuilder<Grid>
	{
		IGridBuilder Create();

		IGridBuilder WithRow(double value, GridUnitType gridUnitType);
	}
}
