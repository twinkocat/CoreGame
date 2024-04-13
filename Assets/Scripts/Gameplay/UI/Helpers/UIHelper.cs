// file UIHelper.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using System.Collections.Generic;
using System.Linq;
using twinkocat.Storages;
using twinkocat.UI.Interfaces;
using UnityEngine;

namespace twinkocat.Gameplay.UI.Helpers
{
    public static class UIHelper
    {
        public static IEnumerable<T> InitViews<T>(IReadOnlyCollection<T> collection) where T : IPresenter
        {
            foreach (var presenter in collection)
            {
                if (!StorageGetter.GetUIStorage().Any(presenter.TryInjectViewComponent))
                    Debug.Log($"View for {presenter.GetType()} not found");}

            return collection;
        }
    }
}