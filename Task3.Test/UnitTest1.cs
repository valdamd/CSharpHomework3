using Xunit;
using FluentAssertions;

namespace Task3.Test;
public class EuclideanGcdTests
{
    [Fact]
    public void Calculate_TwoNumbers_CorrectGcd()
    {
        int result = EuclideanGcd.Calculate(30, 21);
        result.Should().Be(3);
    }

    [Fact]
    public void Calculate_TwoNumbers_WithElapsed_CorrectGcdAndElapsed()
    {
        int result = EuclideanGcd.Calculate(30, 21, out TimeSpan elapsed);
        result.Should().Be(3);
        elapsed.Should().BePositive();
    }

    [Fact]
    public void Calculate_ThreeNumbers_CorrectGcdAndElapsed()
    {
        int result = EuclideanGcd.Calculate(30, 21, 15, out TimeSpan elapsed);
        result.Should().Be(3);
        elapsed.Should().BePositive();
    }

    [Fact]
    public void Calculate_VarArgsNumbers_CorrectGcd()
    {
        int result = EuclideanGcd.Calculate(30, 21, 15, 9);
        result.Should().Be(3);
    }

    [Fact]
    public void Calculate_VarArgsNumbers_WithElapsed_CorrectGcdAndElapsed()
    {
        int result = EuclideanGcd.Calculate(out TimeSpan elapsed, 30, 21, 15, 9);
        result.Should().Be(3);
        elapsed.Should().BePositive();
    }

    [Fact]
    public void Calculate_TwoNegativeNumbers_CorrectGcd()
    {
        int result = EuclideanGcd.Calculate(-30, -21);
        result.Should().Be(3);
    }

    [Fact]
    public void Calculate_PositiveAndNegativeNumbers_CorrectGcd()
    {
        int result = EuclideanGcd.Calculate(30, -21);
        result.Should().Be(3);
    }

    [Fact]
    public void Calculate_WithZero_CorrectGcd()
    {
        int result = EuclideanGcd.Calculate(15, 0);
        result.Should().Be(15);
    }

    [Fact]
    public void Calculate_ZeroWithOtherNumber_CorrectGcd()
    {
        int result = EuclideanGcd.Calculate(0, 21);
        result.Should().Be(21);
    }

    [Fact]
    public void Calculate_EmptyArray_ThrowsException()
    {
        Action act = () => EuclideanGcd.Calculate();
        act.Should().Throw<ArgumentException>()
           .WithMessage("At least one number must be provided.");
    }

    [Fact]
    public void Calculate_EmptyArray_WithElapsed_ThrowsException()
    {
        Action act = () => EuclideanGcd.Calculate(out TimeSpan elapsed);
        act.Should().Throw<ArgumentException>()
           .WithMessage("At least one number must be provided.");
    }

    [Fact]
    public void Calculate_SingleNumber_ReturnsNumber()
    {
        int result = EuclideanGcd.Calculate(42);
        result.Should().Be(42);
    }

    [Fact]
    public void Calculate_SingleNumber_WithElapsed_ReturnsNumber()
    {
        int result = EuclideanGcd.Calculate(out TimeSpan elapsed, 42);
        result.Should().Be(42);
        elapsed.Should().BePositive();
    }

    [Fact]
    public void Calculate_ArrayOfSameNumbers_ReturnsNumber()
    {
        int result = EuclideanGcd.Calculate(7, 7, 7, 7);
        result.Should().Be(7);
    }

    [Fact]
    public void Calculate_ArrayOfSameNumbers_WithElapsed_ReturnsNumber()
    {
        int result = EuclideanGcd.Calculate(out TimeSpan elapsed, 7, 7, 7, 7);
        result.Should().Be(7);
        elapsed.Should().BeGreaterThan(TimeSpan.Zero);
    }

    [Fact]
    public void Calculate_CoprimeNumbers_ReturnsOne()
    {
        int result = EuclideanGcd.Calculate(17, 19);
        result.Should().Be(1);
    }

    [Fact]
    public void Calculate_CoprimeNumbers_WithElapsed_ReturnsOne()
    {
        int result = EuclideanGcd.Calculate(17, 19, out TimeSpan elapsed);
        result.Should().Be(1);
        elapsed.Should().BeGreaterThan(TimeSpan.Zero);
    }

    [Fact]
    public void Calculate_MultipleCoprimeNumbers_ReturnsOne()
    {
        int result = EuclideanGcd.Calculate(13, 17, 19, 23);
        result.Should().Be(1);
    }

    [Fact]
    public void Calculate_MultipleCoprimeNumbers_WithElapsed_ReturnsOne()
    {
        int result = EuclideanGcd.Calculate(out TimeSpan elapsed, 13, 17, 19, 23);
        result.Should().Be(1);
        elapsed.Should().BeGreaterThan(TimeSpan.Zero);
    }

    [Fact]
    public void Calculate_LargeNumbers_CorrectGcd()
    {
        int result = EuclideanGcd.Calculate(1071, 462);
        result.Should().Be(21);
    }

    [Fact]
    public void Calculate_MixedPositiveNegativeZero_CorrectGcd()
    {
        int result = EuclideanGcd.Calculate(60, -30, 0, 15);
        result.Should().Be(15);
    }
}