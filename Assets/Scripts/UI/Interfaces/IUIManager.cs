// file IUIManager.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using System;
using System.Collections.Generic;

namespace twinkocat.UI.Interfaces
{
    public interface IUIManager<T, in TEnum> where TEnum : Enum
    {
        void Initialize(List<IPresenter> presenters);

        void Open(TEnum uiType);
        void Close(TEnum uiType);
    }
}