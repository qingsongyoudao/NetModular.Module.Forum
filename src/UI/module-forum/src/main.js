import WebHost from 'netmodular-module-admin'
import config from './config'
import Forum from './index'

import Vue from 'vue'
// 编辑器
import VueQuillEditor from 'vue-quill-editor'

import 'quill/dist/quill.core.css'
import 'quill/dist/quill.snow.css'
import 'quill/dist/quill.bubble.css'

Vue.use(VueQuillEditor)

// 注入模块
WebHost.registerModule(Forum)

// 启动
WebHost.start(config)
