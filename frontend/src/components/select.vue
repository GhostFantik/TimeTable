<template>
<div class="result">
    <select :multiple="multiple" v-model="result" :value="value" @input="$emit('input', $event.target.value)">
        <option value="default" disabled><slot></slot></option>
        <option v-for="item in values" :key="item.key" :value="item.value">{{item.name}}</option>
    </select>
</div>
</template>
<script>
export default {
  name: "select",
  data: function() {
    return {
      result: "default"
    };
  },
  created() {
    if (this.multiple != undefined) {
      this.result = [];
    }
  },
  props: ["value", "values", "multiple"]
};
</script>

