<template>
  <nm-form-dialog ref="form" v-bind="form" v-on="on" :visible.sync="visible_">
    <el-row>
      <el-col :span="20" :offset="1">
        <el-form-item label="昵称：" prop="nickName">
          <el-input v-model="form.model.nickName" clearable />
        </el-form-item>
        <el-form-item label="性别：" prop="sex">
          <el-input v-model="form.model.sex" clearable />
        </el-form-item>
        <el-form-item label="头像：" prop="avatar">
          <el-input v-model="form.model.avatar" clearable />
        </el-form-item>
        <el-form-item label="邮箱：" prop="email">
          <el-input v-model="form.model.email" clearable />
        </el-form-item>
      </el-col>
    </el-row>
  </nm-form-dialog>
</template>
<script>
import { mixins } from 'netmodular-ui'

const { add, edit, update } = $api.forum.member

export default {
  mixins: [mixins.formSave],
  data() {
    return {
      title: '用户信息',
      actions: { add, edit, update },
      form: {
        model: {
          /** 昵称 */
          nickName: '',
          /** 性别 */
          sex: '',
          /** 头像 */
          avatar: '',
          /** 邮箱 */
          email: ''
        },
        rules: {}
      }
    }
  }
}
</script>
