using System;

public abstract class Empleado
{
    public string Nombre { get; set; }
    public bool MetaAlcanzada { get; set; }

    public Empleado(string nombre, bool metaAlcanzada)
    {
        Nombre = nombre;
        MetaAlcanzada = metaAlcanzada;
    }

    public abstract decimal CalcularSalario();
}

public class DocentePorHora : Empleado
{
    public int HorasTrabajadas { get; set; }
    private const decimal TarifaPorHora = 800m;

    public DocentePorHora(string nombre, int horasTrabajadas)
        : base(nombre, false)  
    {
        HorasTrabajadas = horasTrabajadas;
    }

    public override decimal CalcularSalario()
    {
        return HorasTrabajadas * TarifaPorHora;
    }
}

public class DocenteContratoFijo : Empleado
{
    public decimal SalarioBase { get; set; }

    public DocenteContratoFijo(string nombre, decimal salarioBase, bool metaAlcanzada)
        : base(nombre, metaAlcanzada)
    {
        SalarioBase = salarioBase;
    }

    public override decimal CalcularSalario()
    {
        return MetaAlcanzada ? SalarioBase : SalarioBase / 2;
    }
}

public class EmpleadoAdministrativo : Empleado
{
    public decimal SalarioBase { get; set; }

    public EmpleadoAdministrativo(string nombre, decimal salarioBase, bool metaAlcanzada)
        : base(nombre, metaAlcanzada)
    {
        SalarioBase = salarioBase;
    }

    public override decimal CalcularSalario()
    {
        return MetaAlcanzada ? SalarioBase : SalarioBase / 2;
    }
}

class Program
{
    static void Main(string[] args)
    {
        DocentePorHora docentePorHora = new DocentePorHora("Juan", 40);
        DocenteContratoFijo docenteContratoFijo = new DocenteContratoFijo("María", 50000m, true);
        EmpleadoAdministrativo admin = new EmpleadoAdministrativo("Pedro", 40000m, false);

        Console.WriteLine($"{docentePorHora.Nombre} - Salario: {docentePorHora.CalcularSalario()}");
        Console.WriteLine($"{docenteContratoFijo.Nombre} - Salario: {docenteContratoFijo.CalcularSalario()}");
        Console.WriteLine($"{admin.Nombre} - Salario: {admin.CalcularSalario()}");
    }
}
