using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SharpCRUD.API.Models
{
    public interface IEditCompositeBase
    {
        bool IsSavable { get; }
        bool IsDirty { get; }
        bool IsNew { get; }
        event EventHandler<PropertyChangedEventArgs>? OnChange;
    }

    public abstract class EditCompositeBase<TCompositeDto> : IEditCompositeBase
    {
        public event EventHandler<PropertyChangedEventArgs>? OnChange;

        protected internal TCompositeDto Model { get; set; }
        public bool IsSavable { get => (IsDirty || IsNew); }
        public bool IsDirty { get; protected set; } = false;
        public bool IsNew { get; private set; } = false;

        protected EditCompositeBase(TCompositeDto existingModel, bool isNew)
        {
            Model = existingModel;
            IsNew = isNew;
            SetupProperties();
        }

        protected virtual void SetupProperties()
        {

        }

        protected void EmitChange(object sender, PropertyChangedEventArgs args)
        {
            IsDirty = true;
            OnChange?.Invoke(sender, args);
        }

        protected void FieldChanged(string name)
        {
            EmitChange(this, new PropertyChangedEventArgs(name));
        }

        protected void SubscribeToNotifyChangeProperty(string fieldName, INotifyPropertyChanged property)
        {
            if (property == null)
                return;

            property.PropertyChanged += (s, e) =>
            {
                FieldChanged(fieldName);
            };
        }
    }
}
