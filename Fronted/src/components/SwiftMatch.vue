<template>
  <div>
    <div class="swiftmatch">
      <h3>Filters</h3>
      <b-select v-model="selected" placeholder="Select a Result">
        <option value="Matched">Matched</option>
        <option value="Mismatch">Mismatch</option>
        <option value="Unmatched">Unmatched</option>
      </b-select>
      <div class="card">
        <div class="card-content">
          <div class="content">
            <span>Match Count :</span>
            <span>{{matchCount}}</span>
          </div>
        </div>
      </div>
      <div class="card">
        <div class="card-content">
          <div class="content">
            <span>Mismatch Count :</span>
            <span>{{mismatchCount}}</span>
          </div>
        </div>
      </div>
      <vue-json-to-csv :json-data="data" :csv-title="'My_CSV'">
        <button class="button is-primary">Download Report</button>
      </vue-json-to-csv>
    </div>
    <b-table :data="data" :paginated="true" :per-page="10">
      <template slot-scope="props">
        <b-table-column field="SGRef" label="SG Ref Name">{{ props.row.SGRef }}</b-table-column>
        <b-table-column field="CLRef" label="Client Ref Name">{{ props.row.CLRef }}</b-table-column>
        <b-table-column field="Result" label="Result">{{ props.row.Result }}</b-table-column>
        <b-table-column label="Details">
          <button
            class="button is-primary"
            @click="openModal(props.row.SGRef,props.row.CLRef,props.row.Result)"
          >Deails</button>
        </b-table-column>
      </template>
    </b-table>
    <b-modal :active.sync="isImageModalActive">
      <TableModal :SGData="SGData" :CData="CData" :unMatched="result"></TableModal>
    </b-modal>
  </div>
</template>
<script>
import TableModal from "../components/TableModal.vue";
import VueJsonToCsv from "vue-json-to-csv";
import axios from "axios";
export default {
  components: { VueJsonToCsv, TableModal },
  watch: {
    selected: {
      handler: function(newValue) {
        //debugger;
        this.data = this.tempData.filter(f => f.Result == newValue);
        if (!this.data) this.data = this.tempData;
      }
    }
  },
  data() {
    return {
      result: null,
      tempData: [],
      data: [],
      SGData: null,
      CData: null,
      detailedData: [],
      dTableData: [],
      isImageModalActive: false,
      selected: null,
      columns: [
        {
          field: "SGRef",
          label: "SG Ref Name",
          width: "40"
        },
        {
          field: "CLRef",
          label: "Client Ref Name"
        },
        {
          field: "Result",
          label: "Result"
        }
      ]
    };
  },
  computed: {
    matchCount: function() {
      var Data = this.data.filter(f => f.Result == "Matched");
      return Data.length;
    },
    mismatchCount: function() {
      var Data = this.data.filter(f => f.Result == "Mismatch");
      return Data.length;
    },
    showTableData() {
      // var outputData = [];
      // for(let tData of this.data){
      // }
    }
  },
  mounted() {
    var myData = this;
    axios
      .get("https://localhost:44311/api/SwiftMatch/onetoone")
      .then(function(response) {
        if (response.data) {
          myData.tempData = response.data;
          myData.data = response.data;
        }
      });

    axios
      .get("https://localhost:44311/api/SwiftMatch/onetooneDetail")
      .then(function(response) {
        if (response.data) {
          myData.detailedData = response.data;
        }
      });
  },
  methods: {
    openModal(SGRef, CLRef, Result) {
      this.isImageModalActive = true;
      var localData = this.detailedData;
      for (var item of localData) {
        if (item.ourRef == SGRef) {
          this.SGData = item;
        }
        if (item.ourRef == CLRef) {
          this.CData = item;
        }
      }
      this.result = Result == "Mismatch";
    }
  }
};
</script>
<style>
.swiftmatch {
  display: flex;
  margin-left: 20%;
}
.card {
  max-width: 15%;
  margin: 5px;
}
</style>