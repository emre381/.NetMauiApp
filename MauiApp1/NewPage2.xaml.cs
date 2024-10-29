using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;


namespace MauiApp1;

public partial class NewPage2 : ContentPage
{

    public NewPage2()
	{

        InitializeComponent();
    }
    private void OnCalculateClicked(object sender, EventArgs e)
    {
        // Kullan�c�dan a, b ve c de�erlerini al
        if (double.TryParse(AValue.Text, out double a) &&
            double.TryParse(BValue.Text, out double b) &&
            double.TryParse(CValue.Text, out double c))
        {
            // Denklemin k�klerini hesapla
            CalculateRoots(a, b, c);
        }
        else
        {
            ResultLabel.Text = "L�tfen ge�erli say�lar girin.";
        }
    }

    private void CalculateRoots(double a, double b, double c)
    {
        // Diskriminant� hesapla
        double discriminant = b * b - 4 * a * c;

        if (discriminant > 0)
        {
            // �ki farkl� ger�ek k�k
            double root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            double root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            ResultLabel.Text = $"K�kler: x1 = {root1}, x2 = {root2}";
        }
        else if (discriminant == 0)
        {
            // Tek bir k�k
            double root = -b / (2 * a);
            ResultLabel.Text = $"Tek k�k: x = {root}";
        }
        else
        {
            // Ger�ek k�k yok
            ResultLabel.Text = "Ger�ek k�k yok.";
        }
    }
}