// file IUIManager.cs created by twinkocat
// 
// (c) 2024 twinkocat. All rights reserved.

using System;


namespace twinkocat.UI.Interfaces
{
    public interface IUIManager<T, in TEnum> where TEnum : Enum
    {
        bool IsOpen(TEnum uiType);
        void Open(TEnum uiType);
        void Close(TEnum uiType);
    }
}