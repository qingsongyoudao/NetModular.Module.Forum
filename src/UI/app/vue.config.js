const TerserPlugin = require('terser-webpack-plugin')
const path = require('path')
const isDev = process.env.NODE_ENV === 'development' // 开发环境
// 增加环境变量
process.env.VUE_APP_COPYRIGHT = '版权所有：17mkh.com'
process.env.VUE_APP_BUILD_TIME = require('dayjs')().format('YYYYMDHHmmss')
// 打包输出路径
const outputDir = '../../WebHost/wwwroot/app'

module.exports = {
  devServer: {
    port: 5310
  },
  outputDir: outputDir,
  publicPath: '/app',
  configureWebpack() {
    let config = {}

    if (!isDev) {
      //自定义代码压缩
      config.optimization = {
        minimize: true,
        minimizer: [
          new TerserPlugin({
            cache: true,
            parallel: true,
            sourceMap: false,
            terserOptions: {
              compress: {
                drop_console: true,
                drop_debugger: true
              }
            }
          })
        ]
      }
    }
    return config
  },
  chainWebpack: config => {
    /**
     * 删除懒加载模块的 prefetch preload，降低带宽压力
     * https://cli.vuejs.org/zh/guide/html-and-static-assets.html#prefetch
     * https://cli.vuejs.org/zh/guide/html-and-static-assets.html#preload
     * 而且预渲染时生成的 prefetch 标签是 modern 版本的，低版本浏览器是不需要的
     */
    config.plugins.delete('prefetch').delete('preload')

    //设置别名
    config.resolve.alias.set('@assets', path.join(__dirname, 'src/assets'))

    config
      // 开发环境
      .when(
        isDev,
        // sourcemap不包含列信息
        config => config.devtool('cheap-source-map')
      )
      // 非开发环境
      .when(!isDev, config => {
        config.optimization.runtimeChunk({
          name: 'manifest'
        })
      })
  }
}
