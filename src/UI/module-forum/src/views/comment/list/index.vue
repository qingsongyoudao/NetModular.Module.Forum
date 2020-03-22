<template>
  <nm-list ref="list" v-bind="list">
    <!--查询条件-->
    <template v-slot:querybar>
      <el-form-item label="内容/IP：" prop="content">
        <el-input v-model="list.model.content" clearable />
      </el-form-item>
    </template>
    <!--自定义列-->
    <!-- <template v-slot:col-name="{row}">
        <nm-button :text="row.name" type="text" />
      </template> -->

    <!--操作列-->
    <template v-slot:col-operation="{ row }">
      <nm-button v-bind="buttons.edit" @click="edit(row)" />
      <nm-button-delete v-bind="buttons.del" :id="row.id" :action="removeAction" @success="refresh" />
    </template>

    <save-page :id="curr.id" :visible.sync="dialog.save" @success="refresh" />
  </nm-list>
</template>
<script>
import { mixins } from 'netmodular-ui'
import page from '../index/page'
import cols from './cols'
import SavePage from '../components/save'

const api = $api.forum.comment

export default {
  name: page.name,
  mixins: [mixins.list],
  components: { SavePage },
  props: {
    id: Number,
    readonly_: Boolean
  },
  data() {
    return {
      list: {
        title: page.title,
        cols,
        action: this.query,
        model: {
          /** 回复内容 */
          content: ''
        }
      },
      removeAction: api.remove,
      buttons: page.buttons
    }
  },
  methods: {
    query() {
      return api.query({ topicId: this.id })
    },
    refresh() {
      this.$refs.list.refresh()
    }
  },
  watch: {
    readonly_: {
      immediate: true,
      handler(val) {
        this.list.noQuerybar = val
        this.list.noOperation = val
      }
    }
  }
}
</script>
