using Autofac.Extras.NSubstitute;
using AutoFixture;
using DailyProgrammer.Testing.AutoFixture;
using FluentAssertions;
using LetterValueSum_399;

namespace LetterValueSum_399_Tests
{
    public class LetterValueSumTests
    {
        private readonly AutoSubstitute _autoSub = new();
        private readonly Fixture _autoFixture = new();
        private readonly SpecimenBuilder _specimenBuilder = new(CreateInput());

        public LetterValueSumTests()
        {
            _autoFixture.Customizations.Add(_specimenBuilder);
        }

        private static CreateSpecimen CreateInput(int minLength = 3, int maxLength = 32, char minChar = 'a', char maxChar = 'z')
        {
            return (request, context) =>
            {
                var random = new Random();
                var length = random.Next(minLength, maxLength);
                var specimen = new char[length];

                for (var i = 0; i < length; i++)
                {
                    specimen[i] = (char)random.Next(minChar, maxChar);
                }

                return new string(specimen);
            };
        }

        [Fact]
        public void When_input_is_null_then_throw_argumentexception()
        {
            var sut = _autoSub.Resolve<LetterValueSum>();

            Action action = () => sut.Sum(null);

            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void When_input_contains_upper_case_then_throw_argumentexception()
        {
            _specimenBuilder.SetCreateHandler(CreateInput(3, 32, 'A', 'Z'));

            var input = _autoFixture.Create<string>();

            var sut = _autoSub.Resolve<LetterValueSum>();

            Action action = () => sut.Sum(input);

            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void When_input_contains_numbers_then_throw_argumentexception()
        {
            _specimenBuilder.SetCreateHandler(CreateInput(3, 32, '0', '9'));

            var input = _autoFixture.Create<string>();

            var sut = _autoSub.Resolve<LetterValueSum>();

            Action action = () => sut.Sum(input);

            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void When_input_contains_symbols_then_throw_argumentexception()
        {
            _specimenBuilder.SetCreateHandler(CreateInput(3, 32, ' ', '/'));

            var input = _autoFixture.Create<string>();

            var sut = _autoSub.Resolve<LetterValueSum>();

            Action action = () => sut.Sum(input);

            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void When_input_is_empty_then_return_zero()
        {
            _specimenBuilder.SetCreateHandler(CreateInput(0, 0));

            var input = _autoFixture.Create<string>();

            var sut = _autoSub.Resolve<LetterValueSum>();

            var result = sut.Sum(input);

            result.Should().Be(0);
        }

        [Fact]
        public void When_input_is_happy_path_then_return_sum()
        {
            _specimenBuilder.SetCreateHandler(CreateInput());

            var input = _autoFixture.Create<string>();

            var sut = _autoSub.Resolve<LetterValueSum>();

            var result = sut.Sum(input);

            var expected = input.Sum(i => i - 96);

            result.Should().Be(expected);
        }

        [Fact]
        public void When_input_is_microspectrophotometries_path_then_return_319()
        {
            _specimenBuilder.SetCreateHandler(CreateInput());

            var input = "microspectrophotometries";

            var sut = _autoSub.Resolve<LetterValueSum>();

            var result = sut.Sum(input);

            var expected = input.Sum(i => i - 96);

            result.Should().Be(expected);
        }
    }
}