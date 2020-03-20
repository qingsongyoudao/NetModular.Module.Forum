<template>
  <nm-form-dialog ref="form" v-bind="form" v-on="on" :visible.sync="visible_">
    <el-row>
      <el-col :span="20" :offset="1">
        <el-form-item label="主题ID：" prop="topicId">
          <el-input v-model="form.model.topicId" clearable />
        </el-form-item>
        <el-form-item label="用户编号：" prop="userId">
          <el-input v-model="form.model.userId" clearable />
        </el-form-item>
        <el-form-item label="回复人ID：" prop="to">
          <el-input v-model="form.model.to" clearable />
        </el-form-item>
        <el-form-item label="回复内容：" prop="content">
          <el-input v-model="form.model.content" clearable />
        </el-form-item>
        <el-form-item label="赞数：" prop="upCount">
          <el-input v-model="form.model.upCount" clearable />
        </el-form-item>
        <el-form-item label="踩数：" prop="downCount">
          <el-input v-model="form.model.downCount" clearable />
        </el-form-item>
        <el-form-item label="喜欢数：" prop="likeCount">
          <el-input v-model="form.model.likeCount" clearable />
        </el-form-item>
        <el-form-item label="回复时间：" prop="createdTime">
          <el-input v-model="form.model.createdTime" clearable />
        </el-form-item>
        <el-form-item label="创建IP：" prop="createdIP">
          <el-input v-model="form.model.createdIP" clearable />
        </el-form-item>
      </el-col>
    </el-row>
  </nm-form-dialog>
</template>
<script>
import { mixins } from 'netmodular-ui'

const { add, edit, update } = $api.forum.comment

export default {
  mixins: [mixins.formSave],
  data() {
    return {
      title: '评论信息',
      actions: { add, edit, update },
      form: {
        model: {
          /** 主题ID */
          topicId: '',
          /** 用户编号 */
          userId: '',
          /** 回复人ID */
          to: '',
          /** 回复内容 */
          content: '',
          /** 赞数 */
          upCount: '',
          /** 踩数 */
          downCount: '',
          /** 喜欢数 */
          likeCount: '',
          /** 回复时间 */
          createdTime: '',
          /** 创建IP */
          createdIP: ''
        },
        rules: {}
      }
    }
  }
}
</script>
