using DeclarativeDiagram.DataModel;
using DeclarativeDiagram.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DDClient
{
    public partial class MainForm : Form
    {
        DateTime LastCompiled;
        Code DDCode;
        bool CodeChanged = true;

        public MainForm()
        {
            InitializeComponent();
            LastCompiled = DateTime.Now;

            Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(s => {
                SynchronizationContext ctx = (SynchronizationContext)s;
                while (true)
                {
                    ctx.Post(s2 => StartParallelCompile(), null);

                    Thread.Sleep(1000);
                }
            }, SynchronizationContext.Current);
        }

        private struct ParallelCompilationState
        {
            public SynchronizationContext Sync;
            public string CodeText;
        }

        private struct ParallelCompilationDoneState
        {
            public Exception Error;
            public Code CodeObject;
        }


        private void StartParallelCompile()
        {
            if (!CodeChanged)
                return;
            string text = CodeEditor.Text;
            var ctxStruct = new ParallelCompilationState
            {
                CodeText = text,
                Sync = SynchronizationContext.Current
            };
            ThreadPool.QueueUserWorkItem(s => PerformParallelCompile((ParallelCompilationState)s), ctxStruct);
        }

        private void PerformParallelCompile(ParallelCompilationState s)
        {
            ParallelCompilationDoneState state = new ParallelCompilationDoneState();
            try
            {
                Code code = DiagramParserHelper.ParseCode(s.CodeText);
                state.CodeObject = code;
                
            }
            catch(Exception exc)
            {
                state.Error = exc;
            }

            s.Sync.Post(s_ => FinishParallelCompilation((ParallelCompilationDoneState)s_), state);
        }

        private void FinishParallelCompilation(ParallelCompilationDoneState state)
        {
            if (state.Error != null)
            {

            }
            else
            {
                CodeChanged = false;
                DDCode = state.CodeObject;
                DDCode.Execute();
                UpdateFunctionsList();
            }
        }

        private void UpdateFunctionsList()
        {
            FunctionsComboBox.Items.Clear();
            Text = DDCode.GlobalContext.Values.Count.ToString();
            foreach (var v in DDCode.GlobalContext.Values)
            {
                if (v.Value.GetExprType(DDCode.GlobalContext) == DeclarativeDiagram.DataModel.ValueType.Function)
                {
                    Function fn = (Function)v.Value;
                    FunctionsComboBox.Items.Add(fn.ToMathString());
                }
            }
        }

        private void CodeEditor_TextChanged(object sender, EventArgs e)
        {
            CodeChanged = true;
        }
    }
}
