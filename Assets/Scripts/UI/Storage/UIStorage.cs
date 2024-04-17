// file UIStorage.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using System.Collections;
using System.Collections.Generic;
using twinkocat.Core.Utilities;
using twinkocat.UI.Entities;
using UnityEngine;

namespace twinkocat.UI.Storage
{
    public class UIStorage : ScriptableObject, IEnumerable<View>
    {
        [SerializeField] private View[] views;

        public IEnumerator<View> GetEnumerator()
        {
            return views.GetEnumerable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}