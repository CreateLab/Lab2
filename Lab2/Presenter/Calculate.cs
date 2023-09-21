using Lab2.Presenter.Enum;

namespace Lab2.Presenter;

public class Calculate : ICalculate
{
    private List<double> _values = new();
    private List<Operations> _operators = new();
    private double _result;

    public void SetValue(double value)
    {
        _values.Add(value);
    }

    public void SetOperator(Operations op)
    {
        _operators.Add(op);
    }

    public void CalculateResult()
    {
        CheckData();
        
        var res = _values.First();
        for (var i = 0; i < _operators.Count; i++)
        {
            var op = _operators[i];
            var prev = _values[i +1];

            switch (op)
            {
                case Operations.Sum:
                    res += prev;
                    break;
                case Operations.Sub:
                    res -= prev;
                    break;
                case Operations.Mul:
                    res *= prev;
                    break;
                case Operations.Div:
                    res /= prev;
                    break;
            }
        }

        _result = res;
    }

    private void CheckData()
    {
        if (_operators.Count <= 0 || _values.Count != _operators.Count + 1)
        {
            throw new InvalidDataException();
        }
    }

    public double Result => _result;
}