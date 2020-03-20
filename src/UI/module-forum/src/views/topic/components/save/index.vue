<template>
  <nm-form-dialog ref="form" v-bind="form" v-on="on" :visible.sync="visible_">
    <el-row>
      <el-col :span="10" :offset="1">
        <el-form-item label="用户ID：" prop="userId">
          <el-input v-model="form.model.userId" clearable />
        </el-form-item>
      </el-col>
      <el-col :span="10" :offset="1">
        <el-form-item label="标题：" prop="title">
          <el-input v-model="form.model.title" clearable />
        </el-form-item>
      </el-col>
      <el-col :span="10" :offset="1">
        <el-form-item label="分类ID：" prop="categoryId">
          <el-input v-model="form.model.categoryId" clearable />
        </el-form-item>
      </el-col>
      <el-col :span="10" :offset="1">
        <el-form-item label="内容：" prop="content">
          <el-input v-model="form.model.content" clearable />
        </el-form-item>
      </el-col>
      <el-col :span="10" :offset="1">
        <el-form-item label="预览数：" prop="viewCount">
          <el-input v-model="form.model.viewCount" clearable />
        </el-form-item>
      </el-col>
      <el-col :span="10" :offset="1">
        <el-form-item label="赞数：" prop="upCount">
          <el-input v-model="form.model.upCount" clearable />
        </el-form-item>
      </el-col>
      <el-col :span="10" :offset="1">
        <el-form-item label="踩数：" prop="downCount">
          <el-input v-model="form.model.downCount" clearable />
        </el-form-item>
      </el-col>
      <el-col :span="10" :offset="1">
        <el-form-item label="喜欢数：" prop="likeCount">
          <el-input v-model="form.model.likeCount" clearable />
        </el-form-item>
      </el-col>
      <el-col :span="10" :offset="1">
        <el-form-item label="评论数：" prop="commentCount">
          <el-input v-model="form.model.commentCount" clearable />
        </el-form-item>
      </el-col>
      <el-col :span="10" :offset="1">
        <el-form-item label="创建时间：" prop="createdTime">
          <el-input v-model="form.model.createdTime" clearable />
        </el-form-item>
      </el-col>
      <el-col :span="10" :offset="1">
        <el-form-item label="最后回复时间：" prop="lastReplyTime">
          <el-input v-model="form.model.lastReplyTime" clearable />
        </el-form-item>
      </el-col>
      <el-col :span="10" :offset="1">
        <el-form-item label="发布IP：" prop="createdIP">
          <el-input v-model="form.model.createdIP" clearable />
        </el-form-item>
      </el-col>
      <el-col :span="24" v-if="isEdit_ && form.model.id > 0">
        <nm-tabs :fullscreen="false" border>
          <el-tabs v-model="tab" type="card" @tab-click="onTabClick">
            <el-tab-pane name="topicTag" style="height:400px; padding:10px;">
              <span slot="label">主题标签</span>
              <topic-tag ref="topicTagList" v-bind:topicId="form.model.id" />
            </el-tab-pane>
            <el-tab-pane name="personal" title="评论" style="height:400px;" lazy>
              <span slot="label">评论</span>
            </el-tab-pane>
            <el-tab-pane name="contact" style="height:400px;" lazy>
              <span slot="label">点赞</span>
            </el-tab-pane>
          </el-tabs>
        </nm-tabs>
      </el-col>
    </el-row>
  </nm-form-dialog>
</template>
<script>
import { mixins } from 'netmodular-ui'
import TopicTag from '../../../topicTag/list'
const { add, edit, update } = $api.forum.topic

export default {
  mixins: [mixins.formSave],
  components: { TopicTag },
  data() {
    return {
      title: '主题',
      actions: { add, edit, update },
      form: {
        model: {
          /** 用户ID */
          userId: '',
          /** 标题 */
          title: '',
          /** 分类ID */
          categoryId: '',
          /** 内容 */
          content: '',
          /** 预览数 */
          viewCount: 0,
          /** 赞数 */
          upCount: 0,
          /** 踩数 */
          downCount: 0,
          /** 喜欢数 */
          likeCount: 0,
          /** 评论数 */
          commentCount: 0,
          /** 创建时间 */
          createdTime: '',
          /** 最后回复时间 */
          lastReplyTime: '',
          /** 发布IP */
          createdIP: ''
        },
        rules: {},
        width: '80%'
      },
      tab: 'topicTag'
    }
  },
  methods: {
    refresh() {
      this.$nextTick(() => {
        this.$refs[this.tab].refresh()
      })
    },
    refreshList() {
      this.$emit('success')
    },
    onOpened() {
      if (this.isEdit_) {
        this.tab = 'topicTag'
        this.refresh()
      }
    },
    onTabClick() {
      this.refresh()
    }
  }
}
</script>
