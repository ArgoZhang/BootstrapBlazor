﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using BootstrapBlazor.Components;
using BootstrapBlazor.Shared.Common;
using BootstrapBlazor.Shared.Pages.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace BootstrapBlazor.Shared.Pages
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ValidateForms
    {
        [NotNull]
        private Logger? Trace { get; set; }

        [NotNull]
        private Logger? Trace2 { get; set; }

        [Inject]
        [NotNull]
        private IStringLocalizer<EnumEducation>? Localizer { get; set; }

        [Inject]
        [NotNull]
        private IStringLocalizer<Foo>? LocalizerFoo { get; set; }

        private Foo Model { get; set; } = new();

        private IEnumerable<SelectedItem>? Educations { get; set; }

        [NotNull]
        private IEnumerable<SelectedItem>? Hobbys { get; set; }

        /// <summary>baise
        /// OnInitialized 方法
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();

            // 初始化参数
            Educations = typeof(EnumEducation).ToSelectList(new SelectedItem("", Localizer["PlaceHolder"] ?? "请选择 ..."));
            Hobbys = Foo.GenerateHobbys(LocalizerFoo);
        }

        private Task OnInvalidSubmit1(EditContext context)
        {
            Trace.Log("OnInvalidSubmit 回调委托");
            return Task.CompletedTask;
        }

        private Task OnValidSubmit(EditContext context)
        {
            Trace2.Log("OnValidSubmit 回调委托");
            return Task.CompletedTask;
        }

        private Task OnInvalidSubmit(EditContext context)
        {
            Trace2.Log("OnInvalidSubmit 回调委托");
            return Task.CompletedTask;
        }

        #region 参数说明
        private static IEnumerable<AttributeItem> GetAttributes() => new AttributeItem[]
        {
            // TODO: 移动到数据库中
            new AttributeItem() {
                Name = "Model",
                Description = "表单组件绑定的数据模型，必填属性",
                Type = "object",
                ValueList = " — ",
                DefaultValue = " — "
            },
            new AttributeItem() {
                Name = "ChildContent",
                Description = "子组件模板实例",
                Type = "RenderFragment",
                ValueList = " — ",
                DefaultValue = " — "
            },
            new AttributeItem() {
                Name = "OnSubmit",
                Description = "表单提交时的回调委托",
                Type = "EventCallback<EditContext>",
                ValueList = " — ",
                DefaultValue = " — "
            },
            new AttributeItem() {
                Name = "OnValidSubmit",
                Description = "表单提交时数据合规检查通过时的回调委托",
                Type = "EventCallback<EditContext>",
                ValueList = " — ",
                DefaultValue = " — "
            },
            new AttributeItem() {
                Name = "OnInvalidSubmit",
                Description = "表单提交时数据合规检查未通过时的回调委托",
                Type = "EventCallback<EditContext>",
                ValueList = " — ",
                DefaultValue = " — "
            }
        };

        /// <summary>
        /// 获得事件方法
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<MethodItem> GetMethods() => new MethodItem[]
        {
            new MethodItem()
            {
                Name = "Validate",
                Description="表单验证方法",
                Parameters =" — ",
                ReturnValue = "Task<bool>"
            }
        };
        #endregion
    }
}
