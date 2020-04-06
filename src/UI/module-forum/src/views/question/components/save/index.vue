<template>
  <nm-form-dialog ref="form" v-bind="form" v-on="on" :visible.sync="visible_">
    <el-row>
      <el-col :span="10" :offset="1">
        <el-form-item label="所属分类：" prop="categoryId">
          <nm-select :method="getCategorySelect" v-model="form.model.categoryId" />
        </el-form-item>
      </el-col>
      <el-col :span="10" :offset="1">
        <el-form-item label="标签：" prop="tags">
          <nm-select :method="tagSelect" v-model="form.model.tags" :multiple="true" />
        </el-form-item>
      </el-col>
      <el-col :span="21" :offset="1">
        <el-form-item label="标题：" prop="title">
          <el-input v-model="form.model.title" clearable />
        </el-form-item>
      </el-col>
      <el-col :span="10" :offset="1">
        <el-form-item label="访问次数：" prop="visitCount" v-show="id > 0">
          <el-input v-model="form.model.visitCount" clearable />
        </el-form-item>
      </el-col>
      <el-col :span="10" :offset="1">
        <el-form-item label="回答次数：" prop="answerCount" v-show="id > 0">
          <el-input v-model="form.model.answerCount" clearable />
        </el-form-item>
      </el-col>
      <el-col :span="10" :offset="1">
        <el-form-item label="赞次数：" prop="upCount" v-show="id > 0">
          <el-input v-model="form.model.upCount" clearable />
        </el-form-item>
      </el-col>
      <el-col :span="10" :offset="1">
        <el-form-item label="踩次数：" prop="downCount" v-show="id > 0">
          <el-input v-model="form.model.downCount" clearable />
        </el-form-item>
      </el-col>
      <el-col :span="21" :offset="1">
        <el-form-item label="摘要：" prop="abstract">
          <el-input v-model="form.model.abstract" clearable />
        </el-form-item>
      </el-col>
      <el-col :span="21" :offset="1">
        <el-form-item label="内容：" prop="content">
          <nm-editor-input v-model="form.model.content" />
        </el-form-item>
      </el-col>
    </el-row>
  </nm-form-dialog>
</template>
<script>
import { mixins } from 'netmodular-ui'

const { add, edit, update } = $api.forum.question
const { select } = $api.forum.category
const tagApi = $api.forum.tag

export default {
  mixins: [mixins.formSave],
  data() {
    return {
      title: '问题管理',
      actions: { add, edit, update },
      form: {
        model: {
          /** 标题 */
          title: '',
          /** 分类编号 */
          categoryId: '',
          /** 标签 */
          tags: '',
          /** 访问次数 */
          visitCount: '',
          /** 回答次数 */
          answerCount: '',
          /** 赞次数 */
          upCount: '',
          /** 踩次数 */
          downCount: '',
          /** 问题内容 */
          content: '',
          /** 摘要 */
          abstract: ''
        },
        rules: {},
        width: '80%'
      }
    }
  },
  methods: {
    getCategorySelect() {
      return select()
    },
    tagSelect() {
      return tagApi.select()
    }
  }
}
</script>
