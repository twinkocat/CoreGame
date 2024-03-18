// file UIStorage.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using System.Collections;
using System.Collections.Generic;
using twinkocat.UI.Entities;
using UnityEngine;

namespace twinkocat.UI
{ 
    public class UIStorage : ScriptableObject, IEnumerable<View>
    {
        [SerializeField] private List<View> _views;
        
        
        public IEnumerator<View> GetEnumerator() => _views.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}