using AutoFixture.Kernel;

namespace DailyProgrammer.Testing.AutoFixture
{
    public delegate object? CreateSpecimen(object request, ISpecimenContext context);

    public class SpecimenBuilder : ISpecimenBuilder
    {
        private CreateSpecimen? _createSpecimen;

        public SpecimenBuilder(CreateSpecimen? createSpecimen = null)
        {
            _createSpecimen = createSpecimen;
        }

        public void SetCreateHandler(CreateSpecimen? createSpecimen)
        {
            _createSpecimen = createSpecimen;
        }

        public object Create(object request, ISpecimenContext context)
        {
            return _createSpecimen?.Invoke(request, context) ?? new NoSpecimen();
        }
    }
}
