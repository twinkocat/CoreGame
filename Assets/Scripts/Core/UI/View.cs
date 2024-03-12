// file View.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using twinkocat.Core.UI.Interfaces;
using UnityEngine;

namespace twinkocat.Core.UI
{
    public abstract class View<T> : IView where T : MonoBehaviour
    {
        protected T ViewComponent;

        protected View(T viewComponent) => ViewComponent = viewComponent;
    }
}