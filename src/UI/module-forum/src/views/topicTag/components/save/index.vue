<template>
  <nm-form-dialog ref="form" v-bind="form" v-on="on" :visible.sync="visible_">
    <el-row>
      <el-col :span="20" :offset="1">
        <el-form-item label="主题ID：" prop="topicId">
          <el-input v-model="form.model.topicId" clearable />
        </el-form-item>
        <el-form-item label="标签ID：" prop="tagId">
          <el-input v-model="form.model.tagId" clearable />
        </el-form-item>
      </el-col>
    </el-row>
  </nm-form-dialog>
</template>
<script>
import { mixins } from 'netmodular-ui'

const { add, edit, update } = $api.forum.topicTag

export default {
  mixins: [mixins.formSave],
  data() {
    return {
      title: '主题标签',
      actions: { add, edit, update },
      form: {
        model: {
          /** 主题ID */
          topicId: '',
          /** 标签ID */
          tagId: ''
        },
        rules: {}
      }
    }
  }
}
</script>
