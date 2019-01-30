using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ninject.test.Services
{
    /// <summary>
    /// Get test values
    /// </summary>
    public class ValuesService : IValuesService
    {
        #region Properties
        /// <summary>
        /// just an string list
        /// </summary>
        List<string> StringList { get; set; }
            = new List<string>
                {
                    "value 1",
                    "value 2",
                    "value 3"
                };
        
        #endregion
        #region Public Methods
        /// <summary>
        /// Create a list of strings
        /// </summary>
        /// <returns>{"string 1", "string 2"}</returns>
        public async Task<List<string>> GetValuesAsync()
            => await Task.Run(() => StringsValues());


        /// <summary>
        /// Create new item in string list
        /// </summary>
        /// <param name="val"></param>
        /// <returns>Task</returns>
        public async Task CreateNewItemInStringListAsync(string val)
            => await Task.Run(() => AddNewItemInStringList(val));

        #endregion

        #region Private Methods
        private List<string> StringsValues()
            => StringList;

        private void AddNewItemInStringList(string val)
        {
            StringList.Add(val);
        }
        #endregion
    }
}