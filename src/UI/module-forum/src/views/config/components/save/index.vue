<template>
  <nm-form-dialog ref="form" v-bind="form" v-on="on" :visible.sync="visible_">
    <el-row>
      <el-col :span="20" :offset="1">
        <el-form-item label="参数名称：" prop="key">
          <el-input v-model="form.model.key" clearable />
        </el-form-item>
        <el-form-item label="参数值：" prop="value">
          <el-input v-model="form.model.value" clearable />
        </el-form-item>
        <el-form-item label="参数描述：" prop="remarks">
          <el-input type="textarea" v-model="form.model.remarks" clearable />
        </el-form-item>
      </el-col>
    </el-row>
  </nm-form-dialog>
</template>
<script>
import { mixins } from 'netmodular-ui'

const { add, edit, update } = $api.forum.config

export default {
  mixins: [mixins.formSave],
  data() {
    return {
      title: '论坛参数配置',
      actions: { add, edit, update },
      form: {
        model: {
          /** 参数键 */
          key: '',
          /** 参数值 */
          value: '',
          /** 备注 */
          remarks: ''
        },
        rules: {}
      }
    }
  }
}
</script>
