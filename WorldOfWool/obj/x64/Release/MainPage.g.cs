﻿#pragma checksum "C:\Users\owner\Documents\Visual Studio 2015\Projects\WorldOfWool\WorldOfWool\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "91FD03E44207C34552F36C8448897A20"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WorldOfWool
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)(target);
                    #line 8 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Page)element1).Tapped += this.imgSheep1_Tapped;
                    #line default
                }
                break;
            case 2:
                {
                    this.sbSheep = (global::Windows.UI.Xaml.Media.Animation.Storyboard)(target);
                }
                break;
            case 3:
                {
                    this.sbSmile = (global::Windows.UI.Xaml.Media.Animation.Storyboard)(target);
                }
                break;
            case 4:
                {
                    this.sbTapped = (global::Windows.UI.Xaml.Media.Animation.Storyboard)(target);
                }
                break;
            case 5:
                {
                    this.sbSleep = (global::Windows.UI.Xaml.Media.Animation.Storyboard)(target);
                }
                break;
            case 6:
                {
                    this.grdCanvas = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 7:
                {
                    this.txtbHappiness = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8:
                {
                    this.txtbFriends = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 9:
                {
                    this.btnLove = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 129 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnLove).Click += this.btnLove_click;
                    #line default
                }
                break;
            case 10:
                {
                    this.btnFeedMe = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 130 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnFeedMe).Click += this.btnFeedMe_click;
                    #line default
                }
                break;
            case 11:
                {
                    this.btnPlay = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 135 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnPlay).Click += this.btnPlay_click;
                    #line default
                }
                break;
            case 12:
                {
                    this.imgTapped = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 13:
                {
                    this.imgSleepSmile = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 14:
                {
                    this.imgSmile = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 15:
                {
                    this.imgSleep = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 16:
                {
                    this.imgSheep = (global::Windows.UI.Xaml.Controls.Image)(target);
                    #line 140 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Image)this.imgSheep).Tapped += this.imgSheep1_Tapped;
                    #line default
                }
                break;
            case 17:
                {
                    this.FriendsCount = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 141 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.FriendsCount).Click += this.FriendsCount_Click;
                    #line default
                }
                break;
            case 18:
                {
                    this.btnEnergy = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 142 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnEnergy).Click += this.btnEnergy_Click;
                    #line default
                }
                break;
            case 19:
                {
                    this.txtbEnergy = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 20:
                {
                    this.btnScreenshot = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 145 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnScreenshot).Click += this.btnScreenshot_Click;
                    #line default
                }
                break;
            case 21:
                {
                    this.imageControl = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 22:
                {
                    this.btnInfo = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 149 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnInfo).Click += this.btnInfo_click;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

