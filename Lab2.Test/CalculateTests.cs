using Lab2.Presenter;
using Lab2.Presenter.Enum;

namespace Lab2.Test;

public class CalculateTests
{
   [Fact]
   public void Result_ShouldBeZero()
   {
      var calculate = new Calculate();
      var result = calculate.Result;
      
      Assert.Equal(0, result);
   }

   [Fact]
   public void Result_ShouldBeZero_ReturnFalse()
   {
      var calculate = new Calculate();
      var result = calculate.Result;
      
      Assert.False(result == 1);
   }


   [Theory]
   [InlineData(1, 2, Operations.Sum, 3)]
   [InlineData(1, 2, Operations.Sub, -1)]
   [InlineData(1, 2, Operations.Mul, 2)]
   [InlineData(1, 2, Operations.Div, 0.5)]
   public void CalculateResult_ShouldBe_ReturnExpected(double a, double b, Operations op, double result)
   {
      var calculate = new Calculate();
      calculate.SetValue(a);
      calculate.SetValue(b);
      calculate.SetOperator(op);
      
      calculate.CalculateResult();
      
      Assert.Equal(result, calculate.Result);
   }
   
   [Fact] 
   public void Calculate_WithNoValues_ShouldThrowException()
   {
      var calculate = new Calculate();
      
      calculate.SetOperator(Operations.Sum);
      
      Assert.Throws<InvalidDataException>(() => calculate.CalculateResult());
   }
}