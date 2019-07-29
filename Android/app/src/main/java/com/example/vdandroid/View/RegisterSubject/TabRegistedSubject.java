package com.example.vdandroid.View.RegisterSubject;

import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.support.v7.widget.GridLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.vdandroid.Adapter.RegistedSubjectAdapter;
import com.example.vdandroid.Adapter.RegisterSubjectAdapter;
import com.example.vdandroid.Model.RegistedSubjectModel;
import com.example.vdandroid.Presenter.RegistedSubjectTask;
import com.example.vdandroid.Presenter.RegisterSubjectTask;
import com.example.vdandroid.R;
import com.example.vdandroid.View.Interface.IViewRegistedSubject;

import java.util.ArrayList;
import java.util.List;

public class TabRegistedSubject extends Fragment {
    public static RecyclerView lvRegistedSubject;
    public static RegistedSubjectAdapter adapter;
    //public static RegistedSubjectModel model;
    public static List<RegistedSubjectModel> list;

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view = inflater.inflate( R.layout.tab_registed_subject, container, false);
        onInit(view);
        onGetListSubjects();
        return view;

    }

    private void onGetListSubjects(){
        new RegistedSubjectTask( getContext(), new IViewRegistedSubject() {
            @Override
            public void onGetSuccess() {
                //list = new ArrayList<>();
                //list.add( model );
                adapter = new RegistedSubjectAdapter( getContext(), R.layout.item_registed_subject, list);
                GridLayoutManager gridLayoutManager = new GridLayoutManager(getContext(), 1, GridLayoutManager.VERTICAL, false);
                lvRegistedSubject.setLayoutManager( gridLayoutManager );
                lvRegistedSubject.setAdapter( adapter );
                adapter.notifyDataSetChanged();
            }

            @Override
            public void onGetFail() {

            }
        } ).execute();


    }

    private void onInit(View view){
        lvRegistedSubject = view.findViewById( R.id.lvRegistedSubject );
    }
}
