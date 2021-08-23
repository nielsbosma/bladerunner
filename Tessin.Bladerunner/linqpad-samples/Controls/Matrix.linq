<Query Kind="Program">
  <Reference>C:\Repos\tessin-bladerunner\Tessin.Bladerunner\bin\Debug\net5.0\Tessin.Bladerunner.dll</Reference>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>Tessin.Bladerunner</Namespace>
  <Namespace>Tessin.Bladerunner.Blades</Namespace>
  <Namespace>Tessin.Bladerunner.Controls</Namespace>
  <Namespace>LINQPad.Controls</Namespace>
  <RuntimeVersion>5.0</RuntimeVersion>
</Query>

void Main()
{	
	//Debugger.Launch();

	BladeManager manager = new BladeManager(cssPath: @"C:\Repos\tessin-bladerunner\Tessin.Bladerunner\Themes\Sass\default.css", cssHotReloading: true);
	
	manager.PushBlade(Blade1(), "Matrix");
	
	manager.Dump();
}

static IBladeRenderer Blade1()
{
	return BladeFactory.Make((blade) =>
	{
		List<MatrixCell> list = new();
		void Add(string col, string row, object value)
		{
			list.Add(new MatrixCell(col, row, value));
		}
		
		Add("Apa","Bar",new Tessin.Bladerunner.Controls.Icon(Icons.CoffeeOutline));
		Add("Name","City","Stocholm");
		Add("B","X","Nisse");
		Add("C","Y","Nisse");
		Add("Name","Investor",Layout.Vertical(false, new Button("Hej"),"Hej"));
		
		return Matrix<MatrixCell>.Create(list);
	});
}
