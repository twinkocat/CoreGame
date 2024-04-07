// file UIStorage.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using System.Collections;
using System.Collections.Generic;
using twinkocat.UI.Entities;
using UnityEngine;

namespace twinkocat.Storages
{
    public class UIStorage : ScriptableObject, IEnumerable<View>
    {
        [SerializeField] private View[] _views;

        public IEnumerator<View> GetEnumerator()
        {
            return (IEnumerator<View>)_views.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}