﻿Ext.define("MyApp.view.user.Edit", {
	extend: "Ext.window.Window",
	alias: "widget.useredit",
	title: "编辑用户",
	width: 300,
	height: 200,
	layout: "fit",
	items: {
		xtype: "form",
		margin: 5,
		border: false,
		fieldDefaults: {
			labelAlign: 'left',
			labelWidth: 60
		},
		items: [
            { xtype: "textfield", name: "Name", fieldLabel: "姓名" },
            { xtype: "numberfield", name: "Age", fieldLabel: "年龄" },
            { xtype: "textfield", name: "Phone", fieldLabel: "电话" }
		]
	},
	buttons: [
        { text: "保存", action: "save" }
	]
});