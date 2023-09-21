using Lab2.Presenter;
using Lab2.Presenter.Enum;

namespace Lab2.View;

public class View : IView
{
    private readonly ICalculate _calculate;

    public View(ICalculate calculate)
    {
        _calculate = calculate ?? throw new ArgumentNullException(nameof(calculate));
    }

    public void SetValue()
    {
        Console.Write("\n Enter value: ");
        var value = Convert.ToDouble(Console.ReadLine());
        _calculate.SetValue(value);
    }


    private void SetOperator(string operation)
    {
        var op = operation switch
        {
            "+" => Operations.Sum,
            "-" => Operations.Sub,
            "*" => Operations.Mul,
            "/" => Operations.Div,
            _ => throw new InvalidDataException(),
        };
        _calculate.SetOperator(op);
    }

    public void ShowResult()
    {
        _calculate.CalculateResult();
        Console.WriteLine(_calculate.Result);
    }

    public void Start()
    {
        var isWorking = true;
        var isValue = true;
        while (isWorking)
        {
            if (isValue)
            {
                SetValue();
                isValue = false;
            }
            else
            {
                isValue = true;
                var operation = GetOperation();
                var so = CheckSpecifiedOperation(operation); // q = 
                if (so) isWorking = false;
                else
                {
                    SetOperator(operation);
                }
            }
        }
    }

    private bool CheckSpecifiedOperation(string operation)
    {
        if (operation.Equals("q") || operation.Equals("="))
        {
            if (operation.Equals("="))
                ShowResult();
            return true;
        }
        else
        {
            return false;
        }
    }

    private string GetOperation()
    {
        Console.Write("\n Enter operation: ");
        return Console.ReadLine();
    }
}