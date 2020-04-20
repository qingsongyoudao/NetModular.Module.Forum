import WebHost from 'netmodular-module-admin'
import config from './config'
import Forum from './index'

// 注入模块
WebHost.registerModule(Forum)

// 启动
WebHost.start(config)
