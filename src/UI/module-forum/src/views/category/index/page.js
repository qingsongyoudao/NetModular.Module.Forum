/** 页面信息 */
const page = new (function() {
  this.title = '分类列表'
  this.icon = ''
  this.name = 'forum_category'
  this.path = '/forum/category'

  // 关联权限
  this.permissions = [`${this.name}_query_get`]

  // 按钮
  this.buttons = {
    add: {
      text: '添加',
      type: 'success',
      icon: 'add',
      code: `${this.name}_add`,
      permissions: [`${this.name}_add_post`]
    },
    edit: {
      text: '编辑',
      type: 'text',
      icon: 'edit',
      code: `${this.name}_edit`,
      permissions: [`${this.name}_edit_get`, `${this.name}_update_post`]
    },
    del: {
      text: '删除',
      type: 'text',
      icon: 'delete',
      code: `${this.name}_del`,
      permissions: [`${this.name}_delete_delete`]
    },
    sort: {
      text: '排序',
      icon: 'sort',
      type: 'warning',
      code: `${this.name}_sort`,
      permissions: [`${this.name}_sort_get`, `${this.name}_sort_post`]
    }
  }
})()

/** 路由信息 */
export const route = {
  page,
  component: () => import(/* webpackChunkName: "Forum.Category" */ './index')
}

export default page
