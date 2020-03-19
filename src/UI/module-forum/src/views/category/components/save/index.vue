<template>
  <nm-form-dialog ref="form" v-bind="form" v-on="on" :visible.sync="visible_">
    <el-row>
      <el-col :span="20" :offset="1">
        <el-form-item label="名称：" prop="name">
          <el-input v-model="form.model.name" clearable />
        </el-form-item>
        <el-form-item label="主题数量：" prop="count">
          <el-input v-model="form.model.count" clearable />
        </el-form-item>
      </el-col>
    </el-row>
  </nm-form-dialog>
</template>
<script>
import { mixins } from 'netmodular-ui'

const { add, edit, update } = $api.forum.category

export default {
  mixins: [mixins.formSave],
  data() {
    return {
      title: '分类',
      actions: { add, edit, update },
      form: {
        model: {
          /** 名称 */
          name: '',
          /** 主题数量 */
          count: ''
        },
        rules: {}
      }
    }
  }
}
</script>
