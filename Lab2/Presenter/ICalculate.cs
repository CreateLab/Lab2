using Lab2.Presenter.Enum;

namespace Lab2.Presenter;

public interface ICalculate
{
    void SetValue(double value);
    void SetOperator(Operations op);
    void CalculateResult();
    
    double Result { get; }
}