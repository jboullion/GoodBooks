<template>
<v-container>
    <v-row>
        <v-col cols="12">
            <v-card class="mx-auto my-8" >

                <v-img
                height="250"
                :src="`https://picsum.photos/seed/${book.title}/500/250`"
                ></v-img>

                <v-card-title>{{ book.title }}</v-card-title>

                <v-card-text>
                    <v-row
                        align="center"
                        class="mx-0"
                    >
                        <v-rating
                        :value="4.5"
                        color="amber"
                        dense
                        half-increments
                        readonly
                        size="14"
                        ></v-rating>

                        <div class="grey--text ml-4">4.5 (413)</div>
                    </v-row>

                    <div class="my-4 subtitle-1">
                        {{ book.author }}
                    </div>

                </v-card-text>

                <v-divider class="mx-4"></v-divider>

                

            </v-card>
        </v-col>
    </v-row>
    <v-row>
        <v-col cols="12">
            <h2 class="mb-6">Reviews</h2>
           
            <v-card class="mx-auto mb-6"  v-for="review in 10" :key="review">

                <v-card-text>
                    <v-rating
                    :value="4.5"
                    color="amber"
                    dense
                    half-increments
                    readonly
                    size="14"
                    class="mb-2 "
                    ></v-rating>
                    <div class="mb-1 subtitle-1">
                        {{ book.author }}
                    </div>

                    <div>This is the review text</div>
                </v-card-text>

                
                <v-btn
                    color="red lighten-2"
                    text
                    class="delete"
                    @click="deleteReview(review)"
                >
                    <v-icon color="red lighten-1">mdi-delete</v-icon>
                </v-btn>
            </v-card>
        </v-col>
    </v-row>
</v-container>
</template>

<script lang="ts">
import BookService from "@/services/book-service";
import { Component, Vue } from 'vue-property-decorator';

const bookService = new BookService();

@Component({
    name: 'Book',
    components: { }
})
export default class MyBooks extends Vue {
    // data
    book = {};

    // computed properties


    // lifecycle hooks
    created() {
        if(this.$route.params.bookId){
            const bookId = parseInt(this.$route.params.bookId);
            this.loadBook(bookId);
        }
    }

    loadBook(bookId: number){
        bookService.getBook(bookId)
            .then(res => {
            this.book = res;
            //console.log(this.myBooks);
            })
            .catch(err => console.error(err));
    }



}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped lang="scss">

    .delete {
        position: absolute;
        top: 10px;
        right: 10px;
    }
</style>
