<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Reference Relative="..\..\bin\Debug\netstandard2.0\Tessin.Bladerunner.dll">C:\Repos\tessin-bladerunner\Tessin.Bladerunner\bin\Debug\netstandard2.0\Tessin.Bladerunner.dll</Reference>
  <Namespace>Tessin.Bladerunner</Namespace>
  <Namespace>Tessin.Bladerunner.Blades</Namespace>
  <Namespace>Tessin.Bladerunner.Controls</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>Tessin.Bladerunner.Editors</Namespace>
  <Namespace>LINQPad.Controls</Namespace>
</Query>

void Main()
{		
	BladeManager manager = new BladeManager(showDebugButton:true);
	manager.PushBlade(Blade1(), "Blade1");
	manager.Dump();
}

public class Form {
	
	public string FirstName { get; set; }
	
	public string LastName { get; set; }
	
}

static IBladeRenderer Blade1()
{
	return BladeFactory.Make((blade) =>
	{
		return Layout.Vertical(true, new ContextMenu(new IconButton(Icons.DotsVertical),
			new ContextMenu.Item("Foo", (_) => {
				blade.PushBlade(Blade1());
			}),
			new ContextMenu.Item("Bar", (_) => { })
		), 
		new ContextMenu(new IconButton(Icons.DotsVertical),
			new ContextMenu.Item("Foo", (_) =>
			{
				blade.PushBlade(Blade1());
			}),
			new ContextMenu.Item("Bar", (_) => { })
		));
	});
}

