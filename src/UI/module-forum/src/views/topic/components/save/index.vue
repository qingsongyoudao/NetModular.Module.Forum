<template>
  <nm-form-dialog ref="form" v-bind="form" v-on="on" :visible.sync="visible_">
    <nm-tabs :fullscreen="false" border>
      <el-tabs v-model="tab" type="card" @tab-click="onTabClick">
        <el-tab-pane name="topic" title="主题信息" style="height:400px;padding-top:20px;">
          <span slot="label">主题信息</span>
          <el-row>
            <el-col :span="20" :offset="1">
              <el-form-item label="主题：" prop="tags">
                <!-- <el-tag v-for="item in tags" :key="item.tagId" :type="item.type" effect="dark">
                  {{ item.tagName }}
                </el-tag> -->
                <nm-select :method="tagSelect" v-model="form.model.tags" :multiple="true" />
              </el-form-item>
            </el-col>
            <el-col :span="10" :offset="1">
              <el-form-item label="所属分类：" prop="categoryId">
                <nm-select :method="getCategorySelect" v-model="form.model.categoryId" />
              </el-form-item>
            </el-col>

            <el-col :span="10" :offset="1">
              <el-form-item label="发布用户：" prop="userId">
                <el-input v-model="form.model.userId" clearable />
              </el-form-item>
            </el-col>
            <el-col :span="21" :offset="1">
              <el-form-item label="标题：" prop="title">
                <el-input v-model="form.model.title" clearable />
              </el-form-item>
            </el-col>
            <el-col :span="10" :offset="1" v-if="this.isEdit_">
              <el-form-item label="最后回复时间：" prop="lastReplyTime">
                <el-input v-model="form.model.lastReplyTime" clearable />
              </el-form-item>
            </el-col>
            <el-col :span="10" :offset="1" v-if="this.isEdit_">
              <el-form-item label="发布IP：" prop="createdIP">
                <el-input v-model="form.model.createdIP" clearable />
              </el-form-item>
            </el-col>
            <el-col :span="21" :offset="1" v-if="this.isEdit_">
              <el-form-item label="统计：" prop="content">
                预览数：{{ form.model.viewCount }} 赞数：{{ form.model.upCount }} 踩数：{{ form.model.downCount }} 喜欢数：{{ form.model.likeCount }} 评论数：{{ form.model.commentCount }}
              </el-form-item>
            </el-col>

            <el-col :span="21" :offset="1">
              <el-form-item label="内容：" prop="content">
                <!-- <el-input v-model="form.model.content" clearable /> -->
                <nm-editor-input v-model="form.model.content" />
              </el-form-item>
            </el-col>
          </el-row>
        </el-tab-pane>
        <el-tab-pane name="comment" title="评论" style="height:400px;" lazy>
          <span slot="label">评论</span>
          <comment-list :id="form.model.id" :readonly_="false" />
        </el-tab-pane>
      </el-tabs>
    </nm-tabs>
  </nm-form-dialog>
</template>
<script>
import { mixins } from 'netmodular-ui'
const { add, edit, update } = $api.forum.topic
const { select } = $api.forum.category
const { query } = $api.forum.topicTag
import commentList from '../../../comment/list'
const tagApi = $api.forum.tag

export default {
  mixins: [mixins.formSave],
  components: { commentList },
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
          createdIP: '',
          /** 标签 */
          tags: []
        },
        rules: {},
        width: '80%',
        height: '90%',
        labelWidth: '120px'
      },
      tab: 'topic',
      tags: [
        { tagName: '测试1', tagId: 1, type: 'success' },
        { tagName: '测试2', tagId: 2, type: 'info' }
      ]
    }
  },
  methods: {
    tagSelect() {
      return tagApi.select()
    },
    getCategorySelect() {
      return select()
    },
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
        query({ topicId: this.form.model.id }).then(res => {
          this.tags = res.rows.map(m => {
            return { tagName: m.tagName, tagId: m.tagId, type: 'success' }
          })
        })
      }
    },
    onTabClick() {
      this.refresh()
    }
  }
}
</script>
