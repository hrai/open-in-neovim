using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualStudio.Shell;

namespace OpenInNeovim
{
    public class Options : DialogPage
    {
        const string DefaultPathToExe = @"C:\Program Files (x86)\neovim\bin\nvim-qt.exe";
        const string DefaultArguments = @"";

        [Category("General")]
        [DisplayName("Command line arguments")]
        [Description("Command line arguments to pass to nvim-qt.exe")]
        [DefaultValue(DefaultArguments)]
        public string CommandLineArguments { get; set; } = DefaultArguments;

        [Category("General")]
        [DisplayName("Path to nvim-qt.exe")]
        [Description("Specify the path to nvim-qt.exe.")]
        [DefaultValue(DefaultPathToExe)]
        public string PathToExe { get; set; } = DefaultPathToExe;

        [Category("General")]
        [DisplayName("Open solution/project as regular file")]
        [Description("When true, opens solutions/projects as regular files and does not load folder path into VS Code.")]
        public bool OpenSolutionProjectAsRegularFile { get; set; }

        protected override void OnApply(PageApplyEventArgs e)
        {
            if (!File.Exists(PathToExe))
            {
                e.ApplyBehavior = ApplyKind.Cancel;
                MessageBox.Show($"The file \"{PathToExe}\" doesn't exist.", Vsix.Name, MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            base.OnApply(e);
        }
    }
}
