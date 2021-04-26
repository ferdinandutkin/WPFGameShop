using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFGameShop 
{
    public class TrackableBindableBase : INotifyPropertyChanged
    {
         static bool isUndoProcess = false;
    static bool isRedoProcess = false;

    // Пара стеков для хранения истории
    static Stack<(object Obj, string Prop, object OldValue)> undoHistory
        = new Stack<(object Obj, string Prop, object OldValue)>();

    static Stack<(object Obj, string Prop, object OldValue)> redoHistory
        = new Stack<(object Obj, string Prop, object OldValue)>();

    static void Undo()
    {
        if (undoHistory.Count == 0) return;
        var undo = undoHistory.Pop();
   
        // Обернуто для того чтобы в случае исключения флаг всё равно снимался
        try
        {
            isUndoProcess = true;
            undo.Obj.GetType().GetProperty(undo.Prop).SetValue(undo.Obj, undo.OldValue);
        }
        finally
        {
            isUndoProcess = false;
        }
    }

    static void Redo()
    {
        if (redoHistory.Count == 0) return;
        var redo = redoHistory.Pop();
      
        try
        {
            isRedoProcess = true;
            redo.Obj.GetType().GetProperty(redo.Prop).SetValue(redo.Obj, redo.OldValue);
        }
        finally
        {
            isRedoProcess = false;
        }
    }

    static void SaveHistory(object obj, string propertyName, object value)
    {
        if (isUndoProcess)
        {
            redoHistory.Push((obj, propertyName, value));
    
        }
        else if (isRedoProcess)
        {
            undoHistory.Push((obj, propertyName, value));
       
        }
        else
        {
            undoHistory.Push((obj, propertyName, value));
         
            redoHistory.Clear();
           
        }
    }

    static void ClearHistory()
    {
        undoHistory.Clear();
   
        redoHistory.Clear();
        
    }

        protected void Set<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                SaveHistory(this, propertyName, field);
                field = value;
                NotifyPropertyChanged(propertyName);
            }
             
        }
        public static DelegateCommand UndoCommand { get; }
        = new DelegateCommand(_ => Undo(), _ => undoHistory.Count > 0);
    public static DelegateCommand RedoCommand { get; }
        = new DelegateCommand(_ => Redo(), _ => redoHistory.Count > 0);
    public static DelegateCommand ClearHistoryCommand { get; }
        = new DelegateCommand(_ => ClearHistory());

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
      => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
