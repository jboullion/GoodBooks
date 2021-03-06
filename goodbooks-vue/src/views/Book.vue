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

            <review v-for="review in bookReviews" :key="review"></review>
            <review-form></review-form>
        </v-col>
    </v-row>
</v-container>
</template>

<script lang="ts">
import ReviewService from "@/services/review-service";
import Review from "@/components/Review.vue";
import IReview from "@/types/Review";

import ReviewForm from "@/components/ReviewForm.vue";

import BookService from "@/services/book-service";

import { Component, Vue } from 'vue-property-decorator';

const bookService = new BookService();
  const reviewService = new ReviewService();

@Component({
    name: 'Book',
    components: { 
        Review,
        ReviewForm
    }
})

export default class Book extends Vue {
    // data
    book = {};
    bookReviews: IReview[] = [];

    // computed properties


    // lifecycle hooks
    created() {
        if(this.$route.params.bookId){
            const bookId = parseInt(this.$route.params.bookId);
            this.loadBook(bookId);
            this.loadReviews();
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

    loadReviews(){
        reviewService.getAllBookReviews()
            .then(res => {
            this.bookReviews = res;
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
