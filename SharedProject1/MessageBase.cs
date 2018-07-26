using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public abstract class MessageBase
    {
        #region Protected members
        protected readonly string[] _validNames = new[] { "Danie", "Etienne", "Dimitri" };
        protected string _value;
        #endregion

        public MessageBase(string value = null)
        {
            _value = value;
        }

        #region Methods
        protected abstract string GetMessage();
        #endregion
    }
}
