<template>
  <nm-form-dialog ref="form" v-bind="form" v-on="on" :visible.sync="visible_">
    <el-row>
      <el-col :span="20" :offset="1">
        <el-form-item label="类型：" prop="type">
          <el-input v-model="form.model.type" clearable />
        </el-form-item>
        <el-form-item label="主题Id：" prop="topicId">
          <el-input v-model="form.model.topicId" clearable />
        </el-form-item>
        <el-form-item label="用户Id：" prop="userId">
          <el-input v-model="form.model.userId" clearable />
        </el-form-item>
        <el-form-item label="创建时间：" prop="createdTime">
          <el-input v-model="form.model.createdTime" clearable />
        </el-form-item>
      </el-col>
    </el-row>
  </nm-form-dialog>
</template>
<script>
import { mixins } from 'netmodular-ui'

const { add, edit, update } = $api.forum.mark

export default {
  mixins: [mixins.formSave],
  data() {
    return {
      title: '标记信息',
      actions: { add, edit, update },
      form: {
        model: {
          /** 类型 */
          type: '',
          /** 主题Id */
          topicId: '',
          /** 用户Id */
          userId: '',
          /** 创建时间 */
          createdTime: ''
        },
        rules: {}
      }
    }
  }
}
</script>
